using Core.Platform.Model;
using Core.Platform.Rules;
using Zenject;

namespace Core.Platform.Bootstrap
{
    public class PlatformInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlatformModel>().AsSingle().NonLazy();
            Container.BindInterfacesTo<LostLifeRule>().AsSingle().NonLazy();
        }
    }
}

