using Common.GameStates;
using Common.GameStates.States;
using GameStates;
using GameStates.States;
using Zenject;

namespace Bootstrap
{
    public class GameStatesInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameStateService>().AsSingle().Lazy();
            
            InstallStates();
        }
        
        private void InstallStates()
        {
            InstallAsTransient<DefaultState>();
            InstallAsTransient<InitializeAppState>();
            InstallAsTransient<EnterGameState>();
            InstallAsTransient<WinGameState>();
            InstallAsTransient<LostGameState>();
        }
        
        private void InstallAsTransient<TType>()
        {
            Container
                .BindInterfacesAndSelfTo<TType>()
                .AsTransient();
        }
    }
}