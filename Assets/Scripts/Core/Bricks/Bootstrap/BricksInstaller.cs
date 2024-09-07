using Core.Bricks.Model;
using Core.Bricks.Rules;
using Core.Bricks.Services;
using Zenject;

namespace Core.Bricks.Bootstrap
{
    public class BricksInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<BrickPool>().AsSingle().NonLazy();
            Container.Bind<BricksFactory>().AsSingle().NonLazy();
            
            Container.Bind<BrickModel>().AsTransient().NonLazy();
            
            Container.BindInterfacesAndSelfTo<BricksService>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<SpawnBricksRule>().AsSingle().NonLazy();
        }
    }
}

