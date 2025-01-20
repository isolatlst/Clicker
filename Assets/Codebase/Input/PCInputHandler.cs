using System;
using UnityEngine;
using Zenject;

namespace Codebase.Input
{
    public class PCInputHandler : IInputHandler
    {
        public event Action Clicked;

        private void HandleInput()
        {
            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                Clicked?.Invoke();
            }
        }

        public void LocalUpdate()
        {
            HandleInput();
        }
    }
}