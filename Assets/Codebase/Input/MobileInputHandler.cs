using System;
using UnityEngine;
using Zenject;

namespace Codebase.Input
{
    public class MobileInputHandler : IInputHandler, ITickable
    {
        public event Action Clicked;
        private Touch _touch;

        public void Tick()
        {
            HandleInput();
        }
        
        private void HandleInput()
        {
            if (UnityEngine.Input.touchCount <= 0)
                return;

            _touch = UnityEngine.Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Ended)
                Clicked?.Invoke();
        }
    }
}