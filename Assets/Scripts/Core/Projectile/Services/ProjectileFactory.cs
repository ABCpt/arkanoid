using System.Collections.Generic;
using System.Linq;
using Core.Bricks.View;
using Core.Projectile.Model;
using Core.Projectile.View;
using UnityEngine;
using Zenject;

namespace Core.Projectile.Services
{
    public class ProjectileFactory
    {
        private readonly DiContainer _diContainer;
        private readonly ProjectilePool _projectilePool;

        private readonly List<ProjectileView> _projectileViews = new List<ProjectileView>();

        public ProjectileFactory(ProjectilePool projectilePool, DiContainer diContainer)
        {
            _projectilePool = projectilePool;
            _diContainer = diContainer;
        }

        public ProjectileModel Spawn(Vector2 position, Vector2 direction)
        {
            var model = _diContainer.Resolve<ProjectileModel>();
            
            model
                .SetPosition(position)
                .SetDirection(direction);
            
            var projectileView = _projectilePool.Spawn(typeof(ProjectileView).FullName);

            if (projectileView == null)
            {
                Debug.LogError("There is no item with id " + typeof(ProjectileView).FullName);
                return null;
            }

            projectileView.Initialize(model);
            _projectileViews.Add(projectileView);
            
            return model;
        }

        public void Despawn(ProjectileModel model)
        {
            var projectileView = _projectileViews.FirstOrDefault(data => data.Model == model);
            
            if (projectileView != null)
                _projectilePool.Despawn(projectileView, typeof(BrickView).FullName);
        }
    }
}
