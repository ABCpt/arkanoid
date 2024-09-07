using Core.Level.Interface;
using Core.Player.Model;
using Core.Weapon.Model;
using UnityEngine;

namespace Core.Weapon.Rules
{
    public class SetDirectionWeaponRule : ILevelStartable, ILevelFinishable
    {
        private readonly WeaponModel _weaponModel;
        private readonly PlayerModel _playerModel;
        
        public SetDirectionWeaponRule(WeaponModel weaponModel, PlayerModel playerModel)
        {
            _weaponModel = weaponModel;
            _playerModel = playerModel;
        }

        public void StartLevel()
        {
            _playerModel.UpdatePosition += OnUpdatePosition;
        }
        
        public void FinishLevel()
        {
            _playerModel.UpdatePosition -= OnUpdatePosition;
        }

        private void OnUpdatePosition()
        {
            _weaponModel.SetDirection((Vector2.up + _playerModel.Position).normalized);
        }
    }
}