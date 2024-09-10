using Core.Level.Interface;
using Core.Platform.Model;
using Core.Projectile.Services;
using Core.Weapon.Model;

namespace Core.Weapon.Rules
{
    
    public class ChargeWeaponRule : ILevelStartable, ILevelFinishable
    {
        private readonly WeaponModel _weaponModel;
        private readonly PlatformModel _platformModel;
        
        public ChargeWeaponRule(WeaponModel weaponModel, PlatformModel platformModel)
        {
            _weaponModel = weaponModel;
            _platformModel = platformModel;
        }

        public void StartLevel()
        {
            _weaponModel.WeaponCharge();

            _platformModel.UpdateHealth += OnUpdateHealth;
        }

        public void FinishLevel()
        {
            _platformModel.UpdateHealth -= OnUpdateHealth;
        }
        
        private void OnUpdateHealth()
        {
            if (!_platformModel.IsDead)
                _weaponModel.WeaponCharge();
        }
    }
}
