using System;
using Core.Input.Services;
using Core.Level.Interface;
using Core.Level.Model;
using Core.Weapon.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Input.Rules
{
    public class FireInputRule : ILevelStartable, ILevelFinishable
    {
        private readonly WeaponModel _weaponModel;
        private readonly InputControlService _inputControlService;
        private readonly LevelModel _levelModel;

        private IDisposable _updateStream;

        public FireInputRule(WeaponModel weaponModel, InputControlService inputControlService, LevelModel levelModel)
        {
            _weaponModel = weaponModel;
            _inputControlService = inputControlService;
            _levelModel = levelModel;
        }

        private void Fire(InputAction.CallbackContext callback)
        {
            if(_weaponModel.IsWeaponReady() && !_levelModel.Pause)
                _weaponModel.WeaponAttack();
        }

        public void StartLevel()
        {
            _inputControlService.GetActions().Fire.performed += Fire;
        }
        
        public void FinishLevel()
        {
            _inputControlService.GetActions().Fire.performed -= Fire;
        }
    }
}