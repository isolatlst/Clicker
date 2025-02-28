using System;

namespace Codebase.Infrastructure.Services.Input
{
    public interface IInputHandler
    {
        public event Action Clicked;
    }
}