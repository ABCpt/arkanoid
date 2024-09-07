using System;
using Core.Level.Interface;
using Core.Player.Model;
using Core.Projectile.Services;
using Core.Weapon.Model;
using UnityEngine;

namespace Core.Projectile.Rules
{
    public class SpawnProjectileRule : ILevelStartable, ILevelFinishable
    {
        private readonly ProjectileService _projectileService;
        private readonly WeaponModel _weaponModel;
        private readonly PlayerModel _playerModel;

        private IDisposable _spawnStream;
        private float _spawnTime;

        public SpawnProjectileRule(ProjectileService projectileService, 
            WeaponModel weaponModel, PlayerModel playerModel)
        {
            _projectileService = projectileService;
            _playerModel = playerModel;
            _weaponModel = weaponModel;
        }

        public void StartLevel()
        {
            _weaponModel.Attack += SpawnProjectile;
        }

        private void SpawnProjectile(Vector2 targetPosition)
        {
            _projectileService.SpawnProjectile(_playerModel.Position + _weaponModel.WeaponOffset, targetPosition);
        }

        public void FinishLevel()
        {
            _weaponModel.Attack -= SpawnProjectile;
        }
    }
}
