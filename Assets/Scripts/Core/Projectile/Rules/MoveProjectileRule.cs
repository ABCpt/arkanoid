using System;
using Core.Level.Interface;
using Core.Projectile.Model;
using Core.Projectile.Services;

namespace Core.Projectile.Rules
{
    public class MoveProjectilesRule : ILevelUpdatable
    {
        private readonly ProjectileService _projectileService;
        private IDisposable _updateStream;
        
        public MoveProjectilesRule(ProjectileService projectileService)
        {
            _projectileService = projectileService;
        }
        
        public void UpdateLevel()
        {
            foreach (var model in _projectileService.ProjectileModels)
            {
                MoveProjectile(model);
            }
        }

        private void MoveProjectile(ProjectileModel model)
        {
            model.Move();
        }
    }
}
