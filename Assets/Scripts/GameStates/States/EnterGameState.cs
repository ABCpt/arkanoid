using System.Threading.Tasks;
using Core.Level.Interface;
using Zenject;

namespace GameStates.States
{
    public class EnterGameState : BaseGameState
    {
        private DiContainer _container;
        
        public EnterGameState(DiContainer container)
        {
            _container = container;
        }

        public override Task Enter()
        {
            var startables = _container.ResolveAll<ILevelStartable>();

            foreach (var startable in startables)
            {
                startable.StartLevel();
            }
            
            return base.Enter();
        }

        public override Task Exit()
        {
            var finishables = _container.ResolveAll<ILevelFinishable>();

            foreach (var finishable in finishables)
            {
                finishable.FinishLevel();
            }
            
            return base.Exit();
        }
    }
}