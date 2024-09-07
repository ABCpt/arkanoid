using Core.Data;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
    public class RegistryInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings;
        
        public override void InstallBindings()
        {
            InstallFromInstanceAsSingle(_gameSettings);
        }
        
        private void InstallFromInstanceAsSingle<TType>(TType registry)
        {
            Container
                .BindInterfacesAndSelfTo<TType>()
                .FromInstance(registry)
                .AsSingle();
        }
    }
}