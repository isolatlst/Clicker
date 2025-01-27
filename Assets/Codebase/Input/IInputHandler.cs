using System;

namespace Codebase.Input
{
    public interface IInputHandler
    {
        public event Action Clicked;
    }
}