using System;
using Zenject;

namespace Codebase.Input
{
    public class PCInputHandler : IInputHandler, ITickable
    {
        public event Action Clicked;

        public void Tick()
        {
            HandleInput();
        }
        
        private void HandleInput()
        {
            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                Clicked?.Invoke();
            }
        }
    }
}