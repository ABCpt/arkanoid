using System;
using Core.Player.Model;
using GameStates;
using GameStates.States;
using Zenject;

namespace Core.Level.Rules
{
    public class LostLevelRule : IInitializable, IDisposable
    {
        private readonly PlayerModel _playerModel;
        private readonly GameStateService _gameStateService;
        
        public LostLevelRule(PlayerModel playerModel, GameStateService gameStateService)
        {
            _playerModel = playerModel;
            _gameStateService = gameStateService;
        }
        
        public void Initialize()
        {
            _playerModel.UpdateHealth += CheckLost;
        }

        public void Dispose()
        {
            _playerModel.UpdateHealth -= CheckLost;
        }

        private void CheckLost()
        {
            if (_playerModel.IsDead && _gameStateService.CurrentState is EnterGameState)
                _gameStateService.SetState<LostGameState>();
        }
    }
}