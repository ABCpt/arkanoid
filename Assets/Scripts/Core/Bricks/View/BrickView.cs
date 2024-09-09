using Common.Pool.View;
using Core.Bricks.Data;
using Core.Bricks.Model;
using Core.Data;
using UnityEngine;
using DG.Tweening;
using Zenject;

namespace Core.Bricks.View
{
    public class BrickView : BasePoolable
    {
        [SerializeField] private SpriteRenderer _sprite;
        public BrickModel BrickModel { get; private set; }

        private const float YOffset = 0.1f;
        private const float FirstStepPercent = 0.4f;
        private const float SecondStepPercent = 0.6f;
        
        private Sequence _sequence;

        private BricksConfig _bricksConfig;

        [Inject]
        public void Construct(GameSettings gameSettings)
        {
            _bricksConfig = gameSettings.BricksConfig;
        }
        
        public void Initialize(BrickModel model)
        {
            BrickModel = model;
            model.UpdateBrick += OnUpdateBrick;

            SetPosition();
            SetColor(BrickModel.BrickSettings.Color);
        }

        private void OnUpdateBrick()
        {
            if (!BrickModel.IsDead)
                SetColor(BrickModel.BrickSettings.Color);
            
            _sequence?.Kill();

            _sequence = DOTween.Sequence()
                .Join(transform
                    .DOLocalMoveY(transform.position.y + YOffset, _bricksConfig.DespawnTime * FirstStepPercent)
                    .SetLoops(2, LoopType.Yoyo));
        }
        
        private void SetPosition()
        {
            transform.position = BrickModel.Position;
        }

        private void SetColor(Color color)
        {
            _sprite.color = color;
        }

        public override void OnSpawn(Transform parent)
        {
            _sequence?.Kill();
            
            base.OnSpawn(parent);
        }
        
        public override void OnDespawn(Transform parent)
        {
            BrickModel.UpdateBrick -= OnUpdateBrick;
            
            _sequence?.Kill();

            var color = Color.white;
            
            if (BrickModel.Row < _bricksConfig.RowsColor.Length)
                color = _bricksConfig.RowsColor[BrickModel.Row];

            _sequence = DOTween.Sequence()
                .Append(_sprite.DOColor(color, _bricksConfig.DespawnTime * FirstStepPercent).SetEase(Ease.InBounce))
                .Join(transform
                    .DOLocalMoveY(transform.position.y + YOffset, _bricksConfig.DespawnTime * FirstStepPercent)
                    .SetLoops(2, LoopType.Yoyo))
                .Append(_sprite.DOColor(Color.black, _bricksConfig.DespawnTime * SecondStepPercent))
                .Join(transform.DOLocalMoveY(transform.position.y - YOffset, _bricksConfig.DespawnTime * SecondStepPercent).SetEase(Ease.OutSine))
                .AppendCallback(() =>
                {
                    base.OnDespawn(parent);
                });
        }
    }
}

