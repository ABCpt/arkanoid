using Core.Level.Model;
using Core.Level.Rules;
using Zenject;

namespace Core.Level.Bootstrap
{
    public class LevelInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelModel>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<UpdateLevelRule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<WinLevelRule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<LostLevelRule>().AsSingle().NonLazy();
        }
    }
}

