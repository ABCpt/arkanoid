using Core.Bricks.Bootstrap;
using Core.Input.Bootstrap;
using Core.Level.Bootstrap;
using Core.Platform.Bootstrap;
using Core.Projectile.Bootstrap;
using Core.Weapon.Bootstrap;
using Zenject;

namespace Core.Bootstrap
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<LevelInstaller>();
            Container.Install<PlatformInstaller>();
            Container.Install<InputInstaller>();
            Container.Install<ProjectileInstaller>();
            Container.Install<BricksInstaller>();
            Container.Install<WeaponInstaller>();
        }
    }
}

