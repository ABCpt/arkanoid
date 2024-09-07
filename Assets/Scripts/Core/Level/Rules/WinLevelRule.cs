using Core.Level.Interface;
using Core.Level.Model;
using GameStates;
using GameStates.States;

namespace Core.Level.Rules
{
    public class WinLevelRule : ILevelStartable, ILevelFinishable
    {
        private readonly LevelModel _levelModel;
        private readonly GameStateService _gameStateService;

        public WinLevelRule(LevelModel levelModel, GameStateService gameStateService)
        {
            _levelModel = levelModel;
            _gameStateService = gameStateService;
        }

        public void StartLevel()
        {
            _levelModel.LevelCompleted += OnComplete;
        }

        public void FinishLevel()
        {
            _levelModel.LevelCompleted -= OnComplete;
        }
        
        private void OnComplete()
        {
            if(_gameStateService.CurrentState is EnterGameState)
                _gameStateService.SetState<WinGameState>();
        }
    }
}
