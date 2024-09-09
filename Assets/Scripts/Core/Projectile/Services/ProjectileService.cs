using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Bricks.Model;
using Core.Level.Interface;
using Core.Projectile.Model;
using UnityEngine;

namespace Core.Projectile.Services
{
    public class ProjectileService : ILevelFinishable
    {
        public event Action Despawn = delegate {  };

        private readonly ProjectileFactory _projectileFactory;

        public List<ProjectileModel> ProjectileModels { get; private set; }  = new List<ProjectileModel>();

        public ProjectileService(ProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
        }

        public void SpawnProjectile(Vector2 position, Vector2 targetPosition)
        {
            var direction = (targetPosition - position).normalized;
            var model = _projectileFactory.Spawn(position, direction);
            ProjectileModels.Add(model);
        }

        public void DespawnProjectile(ProjectileModel model)
        {
            if (ProjectileModels.Contains(model))
                ProjectileModels.Remove(model);
            
            _projectileFactory.Despawn(model);
            
            Despawn?.Invoke();
        }
        
        public void ReflectProjectile(ProjectileModel projectileModel, Vector2 normal)
        {
            projectileModel.Reflect(normal.normalized);
        }
        
        public async void FinishLevel()
        {
            await Task.Yield();
            
            foreach (var enemyModel in ProjectileModels)
            {
                _projectileFactory.Despawn(enemyModel);
            }
            ProjectileModels?.Clear();
        }
    }
}
