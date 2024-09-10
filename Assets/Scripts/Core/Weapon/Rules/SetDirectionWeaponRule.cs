using Core.Level.Interface;
using Core.Platform.Model;
using Core.Weapon.Model;
using UnityEngine;

namespace Core.Weapon.Rules
{
    public class SetDirectionWeaponRule : ILevelStartable, ILevelFinishable
    {
        private readonly WeaponModel _weaponModel;
        private readonly PlatformModel _platformModel;

        private float OffsetYTarget = 10f;
        
        public SetDirectionWeaponRule(WeaponModel weaponModel, PlatformModel platformModel)
        {
            _weaponModel = weaponModel;
            _platformModel = platformModel;
        }

        public void StartLevel()
        {
            _platformModel.UpdatePosition += OnUpdatePosition;
        }
        
        public void FinishLevel()
        {
            _platformModel.UpdatePosition -= OnUpdatePosition;
        }

        private void OnUpdatePosition()
        {
            _weaponModel.SetDirection((OffsetYTarget * Vector2.up + _platformModel.Position).normalized);
        }
    }
}