using Core.Player.Model;
using Core.Player.Rules;
using Zenject;

namespace Core.Player.Bootstrap
{
    public class PlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle().NonLazy();
            Container.BindInterfacesTo<LostLifeRule>().AsSingle().NonLazy();
        }
    }
}

