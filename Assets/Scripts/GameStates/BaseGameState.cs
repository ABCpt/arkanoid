using System.Threading.Tasks;
using Common.GameStates;

namespace GameStates
{
    public abstract class BaseGameState : IGameState
    {
        public virtual Task Enter()
        {
            UnityEngine.Debug.Log($"[GameState] Enter into {GetType().Name}.");

            return Task.CompletedTask;
        }

        public virtual Task Resume()
        {
            UnityEngine.Debug.Log($"[GameState] Resume {GetType().Name}.");

            return Task.CompletedTask;
        }

        public virtual Task Exit()
        {
            UnityEngine.Debug.Log($"[GameState] Exit from {GetType().Name}.");

            return Task.CompletedTask;
        }
    }
}