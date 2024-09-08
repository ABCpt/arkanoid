using System.Threading.Tasks;
using Core.Level.Model;

namespace GameStates.States
{
    public class LostGameState : BaseGameState
    {
        private readonly LevelModel _levelModel;
        public LostGameState(LevelModel levelModel)
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