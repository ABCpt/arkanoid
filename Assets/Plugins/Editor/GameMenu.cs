using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plugins.Editor
{
    public static class GameMenu
    {
        [MenuItem("Game/Start Game &F5", false, int.MinValue)]
        public static void StartGame()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                EditorSceneManager.SaveOpenScenes();

            EditorSceneManager.OpenScene($"Assets/Scenes/Preloader.unity", OpenSceneMode.Single);
            EditorApplication.isPlaying = true;
        }
    }
}