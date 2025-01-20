using System;
using UnityEngine;

namespace Codebase.Input
{
    public interface IInputHandler
    {
        public event Action Clicked;
        public void LocalUpdate();
    }
}