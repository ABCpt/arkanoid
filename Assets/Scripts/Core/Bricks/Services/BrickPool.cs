using Common.Pool.Services;
using Core.Bricks.Data;
using Core.Bricks.View;
using Core.Data;
using UnityEngine;
using Zenject;

namespace Core.Bricks.Services
{
    public class BrickPool : BasePool<BrickView>
    {
        private readonly BricksConfig _bricksConfig;
        protected override int MaxPoolSize => 200;
        
        public BrickPool(DiContainer diContainer, GameSettings gameSettings) : base(diContainer)
        {
            _bricksConfig = gameSettings.BricksConfig;
        }

        protected override GameObject GetPrefab()
        {
            return _bricksConfig.BrickPrefab.gameObject;
        }
    }
}