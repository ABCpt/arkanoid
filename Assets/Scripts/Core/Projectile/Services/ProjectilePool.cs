using Common.Pool.Services;
using Core.Data;
using Core.Projectile.Data;
using Core.Projectile.View;
using UnityEngine;
using Zenject;

namespace Core.Projectile.Services
{
    public class ProjectilePool : BasePool<ProjectileView>
    {
        private readonly ProjectileConfig _projectileConfig;
        protected override int MaxPoolSize => 5;
        
        public ProjectilePool(DiContainer diContainer, GameSettings gameSettings) : base(diContainer)
        {
            _projectileConfig = gameSettings.ProjectileConfig;
        }

        protected override GameObject GetPrefab()
        {
            return _projectileConfig.ProjectilePrefab.gameObject;
        }
    }
}