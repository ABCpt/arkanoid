using System;
using Core.Input.Services;
using Core.Level.Interface;
using Core.Player.Model;
using UnityEngine;

namespace Core.Input.Rules
{
    public class MoveInputRule : ILevelUpdatable
    {
        private readonly PlayerModel _playerModel;
        private readonly InputControlService _inputControlService;

        private IDisposable _updateStream;

        public MoveInputRule(PlayerModel playerModel, InputControlService inputControlService)
        {
            _playerModel = playerModel;
            _inputControlService = inputControlService;
        }
        
        public void UpdateLevel()
        {
            var direction = _inputControlService.GetActions().Move.ReadValue<Vector2>();

            if (direction != Vector2.zero)
                _playerModel.Move(direction);
            else
            {
                _playerModel.StopMove();
            }
        }
    }
}