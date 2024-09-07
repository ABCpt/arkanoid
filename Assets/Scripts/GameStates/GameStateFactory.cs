using Zenject;

namespace Common.GameStates
{
    public class GameStateFactory
    {
        private readonly DiContainer _container;

        public GameStateFactory(DiContainer container)
        {
            _container = container;
        }

        public TCommand Create<TCommand>()
        {
            return _container.Resolve<TCommand>();
        }
    }
}