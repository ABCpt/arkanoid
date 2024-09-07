using System;
using Core.Input.Services;
using Core.Level.Interface;
using Core.Weapon.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Input.Rules
{
    public class FireInputRule : ILevelStartable, ILevelFinishable
    {
        private readonly WeaponModel _weaponModel;
        private readonly InputControlService _inputControlService;

        private IDisposable _updateStream;

        public FireInputRule(WeaponModel weaponModel, InputControlService inputControlService)
        {
            _weaponModel = weaponModel;
            _inputControlService = inputControlService;
        }

        private void Fire(InputAction.CallbackContext callback)
        {
            if(_weaponModel.IsWeaponReady())
                _weaponModel.WeaponAttack();
        }

        public void StartLevel()
        {
            _inputControlService.GetActions().Fire.performed += Fire;
            
            Debug.Log("Start Level");
        }
        
        public void FinishLevel()
        {
            _inputControlService.GetActions().Fire.performed -= Fire;
        }
    }
}