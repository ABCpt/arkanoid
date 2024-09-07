using System;
using System.Threading.Tasks;
using SceneLoader;
using Zenject;

namespace GameStates.States
{
    public class InitializeAppState : BaseGameState
    {
        private readonly ZenjectSceneLoader _sceneLoader;
        
        public InitializeAppState(ZenjectSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public override async Task Enter()
        {
            await base.Enter();

            await Task.Delay(TimeSpan.FromSeconds(1f));
            
            var asyncLoad = _sceneLoader.LoadSceneAsync(SceneConst.Game);
            
            while (!asyncLoad.isDone)
            {
                await Task.Yield();
            }
        }
    }
}