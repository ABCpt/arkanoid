using System;
using Core.Platform.Model;
using GameStates;
using GameStates.States;
using Zenject;

namespace Core.Level.Rules
{
    public class LostLevelRule : IInitializable, IDisposable
    {
        private readonly PlatformModel _platformModel;
        private readonly GameStateService _gameStateService;
        
        public LostLevelRule(PlatformModel platformModel, GameStateService gameStateService)
        {
            _platformModel = platformModel;
            _gameStateService = gameStateService;
        }
        
        public void Initialize()
        {
            _platformModel.UpdateHealth += CheckLost;
        }

        public void Dispose()
        {
            _platformModel.UpdateHealth -= CheckLost;
        }

        private void CheckLost()
        {
            if (_platformModel.IsDead && _gameStateService.CurrentState is EnterGameState)
            {
                _gameStateService.SetState<LostGameState>();
            }
        }
    }
}