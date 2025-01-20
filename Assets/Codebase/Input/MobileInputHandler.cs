using System;
using UnityEngine;

namespace Codebase.Input
{
    public class MobileInputHandler : IInputHandler
    {
        public event Action Clicked;
        private Touch _touch;

        private void HandleInput()
        {
            if (UnityEngine.Input.touchCount <= 0)
                return;

            _touch = UnityEngine.Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Ended)
                Clicked?.Invoke();
        }

        public void LocalUpdate()
        {
            HandleInput();
        }
    }
}