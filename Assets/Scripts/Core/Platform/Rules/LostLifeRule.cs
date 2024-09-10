using Core.Level.Interface;
using Core.Platform.Model;
using Core.Projectile.Services;

namespace Core.Platform.Rules
{
    public class LostLifeRule : ILevelStartable, ILevelFinishable
    {
        private readonly PlatformModel _platformModel;
        private readonly ProjectileService _projectileService;

        public LostLifeRule(PlatformModel platformModel, ProjectileService projectileService)
        {
            _platformModel = platformModel;
            _projectileService = projectileService;
        }

        public void StartLevel()
        {
            _projectileService.Despawn += OnProjectileDespawn;
        }

        public void FinishLevel()
        {
            _projectileService.Despawn -= OnProjectileDespawn;
        }

        private void OnProjectileDespawn()
        {
            _platformModel.Damage(1);
        }
    }
}
