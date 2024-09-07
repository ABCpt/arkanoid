using System;
using Core.Data;
using Core.Weapon.Data;
using UnityEngine;

namespace Core.Weapon.Model
{
    public class WeaponModel
    {
        private readonly WeaponConfig _weaponConfig;
        private Vector2 _direction;

        public event Action Charge = delegate { };
        public event Action<Vector2> Attack = delegate { };
        private bool _isReady;

        public Vector2 WeaponOffset => _weaponConfig.WeaponOffset;

        public WeaponModel(GameSettings gameSettings)
        {
            _weaponConfig = gameSettings.WeaponConfig;
        }

        public bool IsWeaponReady()
        {
            return _isReady;
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void WeaponCharge()
        {
            _isReady = true;
            Charge?.Invoke();
        }

        public void WeaponAttack()
        {
            _isReady = false;
            Attack?.Invoke(_direction);
        }
    }
}