using System.Threading.Tasks;
using Core.Level.Model;

namespace GameStates.States
{
    public class WinGameState : BaseGameState
    {
        private readonly LevelModel _levelModel;
        public WinGameState(LevelModel levelModel)
        {
            _levelModel = levelModel;
        }
        
        public override Task Enter()
        {
            _levelModel.SetPause(true);
            
            return base.Enter();
        }
    }
}