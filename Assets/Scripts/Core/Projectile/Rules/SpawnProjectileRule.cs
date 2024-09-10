using System;
using Core.Level.Interface;
using Core.Platform.Model;
using Core.Projectile.Services;
using Core.Weapon.Model;
using UnityEngine;

namespace Core.Projectile.Rules
{
    public class SpawnProjectileRule : ILevelStartable, ILevelFinishable
    {
        private readonly ProjectileService _projectileService;
        private readonly WeaponModel _weaponModel;
        private readonly PlatformModel _platformModel;

        private IDisposable _spawnStream;
        private float _spawnTime;

        public SpawnProjectileRule(ProjectileService projectileService, 
            WeaponModel weaponModel, PlatformModel platformModel)
        {
            _projectileService = projectileService;
            _platformModel = platformModel;
            _weaponModel = weaponModel;
        }

        public void StartLevel()
        {
            _weaponModel.Attack += SpawnProjectile;
        }

        private void SpawnProjectile(Vector2 targetPosition)
        {
            _projectileService.SpawnProjectile(_platformModel.Position + _weaponModel.WeaponOffset, targetPosition);
        }

        public void FinishLevel()
        {
            _weaponModel.Attack -= SpawnProjectile;
        }
    }
}
