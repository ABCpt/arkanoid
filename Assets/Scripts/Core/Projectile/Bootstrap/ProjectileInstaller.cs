using Core.Projectile.Model;
using Core.Projectile.Rules;
using Core.Projectile.Services;
using Zenject;

namespace Core.Projectile.Bootstrap
{
    public class ProjectileInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<ProjectilePool>().AsSingle().NonLazy();
            Container.Bind<ProjectileFactory>().AsSingle().NonLazy();
            Container.Bind<ProjectileModel>().AsTransient().NonLazy();
            
            Container.BindInterfacesAndSelfTo<ProjectileService>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<SpawnProjectileRule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MoveProjectilesRule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DespawnOutsideProjectilesRule>().AsSingle().NonLazy();            
            Container.BindInterfacesTo<CollisionProjectileRule>().AsSingle().NonLazy();
        }
    }
}

