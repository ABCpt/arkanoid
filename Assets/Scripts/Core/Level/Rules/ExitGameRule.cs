using System;
using Core.Input.Services;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.Level.Rules
{
    public class ExitGameRule : IInitializable, IDisposable
    {
        private readonly InputControlService _inputControlService;
        
        public ExitGameRule(InputControlService inputControlService)
        {
            _inputControlService = inputControlService;
        }
        
        public void Initialize()
        {
            _inputControlService.GetActions().AnyKey.performed += OnExitGame;
        }

        public void Dispose()
        {
            _inputControlService.GetActions().AnyKey.performed -= OnExitGame;
        }

        private void OnExitGame(InputAction.CallbackContext callback)
        {
            if (Keyboard.current.escapeKey.isPressed)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }
    }
}