using Codebase.Infrastructure.Services;
using Zenject;

namespace Codebase.Infrastructure.Installers.ProjectContext.Installers
{
    public class StoreServiceInstaller : Installer<StoreServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<StoreDataService>()
                .AsSingle();
        }
    }
}