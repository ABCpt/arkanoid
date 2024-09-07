using System.Collections.Generic;
using System.Linq;
using Core.Bricks.Data;
using Core.Bricks.Model;
using Core.Bricks.View;
using UnityEngine;
using Zenject;

namespace Core.Bricks.Services
{
    public class BricksFactory
    {
        private readonly DiContainer _diContainer;
        private readonly BrickPool _effectsPool;

        private readonly List<BrickView> _enemyViews = new List<BrickView>();

        public BricksFactory(BrickPool effectsPool, DiContainer diContainer)
        {
            _effectsPool = effectsPool;
            _diContainer = diContainer;
        }

        public BrickModel Spawn(Vector2 position, BrickType brickType, int row)
        {
            var model = _diContainer.Resolve<BrickModel>();
            model.Initialize(position, brickType, row);
            
            var enemyView = _effectsPool.Spawn(typeof(BrickView).FullName);

            if (enemyView == null)
            {
                Debug.LogError("There is no item with id " + typeof(BrickView).FullName);
                return null;
            }

            enemyView.Initialize(model);
            _enemyViews.Add(enemyView);
            
            return model;
        }

        public void Despawn(BrickModel model)
        {
            var enemyView = _enemyViews.FirstOrDefault(data => data.BrickModel == model);
            
            if (enemyView != null)
                _effectsPool.Despawn(enemyView, typeof(BrickView).FullName);
        }
    }
}
