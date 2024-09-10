using System;
using Core.Input.Services;
using Core.Level.Interface;
using Core.Platform.Model;
using UnityEngine;

namespace Core.Input.Rules
{
    public class MoveInputRule : ILevelUpdatable
    {
        private readonly PlatformModel _platformModel;
        private readonly InputControlService _inputControlService;

        private IDisposable _updateStream;

        public MoveInputRule(PlatformModel platformModel, InputControlService inputControlService)
        {
            _platformModel = platformModel;
            _inputControlService = inputControlService;
        }
        
        public void UpdateLevel()
        {
            var direction = _inputControlService.GetActions().Move.ReadValue<Vector2>();

            if (direction != Vector2.zero)
                _platformModel.Move(direction);
            else
            {
                _platformModel.StopMove();
            }
        }
    }
}