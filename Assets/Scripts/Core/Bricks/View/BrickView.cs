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

        private const float DespawnDelay = 0.16f;
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
                .Append(_sprite.DOColor(color, DespawnDelay * 0.4f).SetEase(Ease.InBounce))
                .Append(_sprite.DOColor(Color.black, DespawnDelay * 0.6f))
                .AppendCallback(() =>
                {
                    base.OnDespawn(parent);
                });
        }
    }
}

