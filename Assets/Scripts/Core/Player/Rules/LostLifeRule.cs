using Core.Level.Interface;
using Core.Player.Model;
using Core.Projectile.Services;

namespace Core.Player.Rules
{
    public class LostLifeRule : ILevelStartable, ILevelFinishable
    {
        private readonly PlayerModel _playerModel;
        private readonly ProjectileService _projectileService;

        public LostLifeRule(PlayerModel playerModel, ProjectileService projectileService)
        {
            _playerModel = playerModel;
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
            _playerModel.Damage(1);
        }
    }
}
