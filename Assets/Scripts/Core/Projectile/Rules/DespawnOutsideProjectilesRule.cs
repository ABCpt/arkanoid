using System;
using System.Collections.Generic;
using Core.Data;
using Core.Level.Data;
using Core.Level.Interface;
using Core.Projectile.Model;
using Core.Projectile.Services;

namespace Core.Projectile.Rules
{
    public class DespawnOutsideProjectilesRule : ILevelUpdatable
    {
        private readonly ProjectileService _projectileService;
        private readonly LevelConfig _levelConfig;
        
        private List<ProjectileModel> _despawnProjectiles = new ();
        private IDisposable _updateStream;

        public DespawnOutsideProjectilesRule(ProjectileService projectileService, GameSettings gameSettings)
        {
            _projectileService = projectileService;
            _levelConfig = gameSettings.LevelConfig;
        }
        
        public void UpdateLevel()
        {
            foreach (var model in _projectileService.ProjectileModels)
            {
                if (IsProjectileOutside(model))
                    _despawnProjectiles.Add(model);
            }

            foreach (var model in _despawnProjectiles)
            {
                _projectileService.DespawnProjectile(model);
            }
            
            _despawnProjectiles?.Clear();
        }

        private bool IsProjectileOutside(ProjectileModel model)
        {
           return model.Position.y < -_levelConfig.CameraSize;
        }
    }
}
