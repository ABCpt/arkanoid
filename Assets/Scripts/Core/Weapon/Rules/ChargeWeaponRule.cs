using Core.Level.Interface;
using Core.Player.Model;
using Core.Projectile.Services;
using Core.Weapon.Model;

namespace Core.Weapon.Rules
{
    
    public class ChargeWeaponRule : ILevelStartable, ILevelFinishable
    {
        private readonly WeaponModel _weaponModel;
        private readonly PlayerModel _playerModel;
        
        public ChargeWeaponRule(WeaponModel weaponModel, PlayerModel playerModel)
        {
            _weaponModel = weaponModel;
            _playerModel = playerModel;
        }

        public void StartLevel()
        {
            _weaponModel.WeaponCharge();

            _playerModel.UpdateHealth += OnUpdateHealth;
        }

        public void FinishLevel()
        {
            _playerModel.UpdateHealth -= OnUpdateHealth;
        }
        
        private void OnUpdateHealth()
        {
            if (!_playerModel.IsDead)
                _weaponModel.WeaponCharge();
        }
    }
}
