using System;

namespace Core.Input.Services
{
    public class InputControlService :  IDisposable
    {
        private MainControls _mainControls;
        
        private void Initialize()
        {
            _mainControls = new MainControls();
            _mainControls.Enable();
        }

        public MainControls.MainActions GetActions()
        {
            if (_mainControls == null)
            {
                Initialize();
            }

            return _mainControls.Main;
        }

        public void Dispose()
        {
            _mainControls?.Disable();
        }
    }
}