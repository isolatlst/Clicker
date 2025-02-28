using Codebase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Installers.ProjectContext.Installers
{
    public class InputInstaller : Installer<InputInstaller>
    {
        public override void InstallBindings()
        {
            if (Application.isMobilePlatform)
                Container.BindInterfacesAndSelfTo<MobileInputHandler>().AsSingle();
            else
                Container.BindInterfacesAndSelfTo<PCInputHandler>().AsSingle();
        }
    }
}