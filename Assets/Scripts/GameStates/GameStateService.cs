using System;
using System.Threading.Tasks;
using Common.GameStates;
using Common.GameStates.States;
using GameStates.States;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class GameStateService : IInitializable
    {
        public event Action<BaseGameState> ChangeState = delegate { };

        private GameStateFactory _stateFactory;
        public BaseGameState CurrentState { get; private set; }

        public GameStateService(GameStateFactory stateFactory)
        {
            _stateFactory = stateFactory;

            CurrentState = _stateFactory.Create<DefaultState>();
        }

        public async void Initialize()
        {
            await SetState<InitializeAppState>();
            
            await Task.Yield();
            
            await SetState<EnterGameState>();
        }

        public async Task SetState<T>() where T : BaseGameState
        {
            await CurrentState.Exit();
            CurrentState = _stateFactory.Create<T>();
            await CurrentState.Enter();

            ChangeState?.Invoke(CurrentState);
        }
    }
}