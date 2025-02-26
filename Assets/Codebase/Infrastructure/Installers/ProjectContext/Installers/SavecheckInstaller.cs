using Codebase.Services;
using Zenject;

namespace Codebase.Infrastructure.Installers.ProjectContext.Installers
{
    public class SavecheckInstaller : Installer<SavecheckInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SavecheckService>()
                .AsSingle();
        }
    }
}