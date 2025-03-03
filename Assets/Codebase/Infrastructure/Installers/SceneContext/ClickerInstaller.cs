using Codebase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Installers.SceneContext
{
    public class ClickerInstaller : MonoInstaller
    {
        [SerializeField] private CommonClickHandler _inputHandler;

        public override void InstallBindings()
        {
            Container
                .Bind<IInputHandler>()
                .FromInstance(_inputHandler)
                .AsSingle();
        }
    }
}