using System.Threading.Tasks;

namespace Common.GameStates
{
    public interface IGameState
    {
        Task Enter();
        Task Exit();
        Task Resume();
    }
}