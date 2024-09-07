using Core.Input.Rules;
using Core.Input.Services;
using Zenject;

namespace Core.Input.Bootstrap
{
    public class InputInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputControlService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MoveInputRule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<FireInputRule>().AsSingle().NonLazy();
        }
    }
}

