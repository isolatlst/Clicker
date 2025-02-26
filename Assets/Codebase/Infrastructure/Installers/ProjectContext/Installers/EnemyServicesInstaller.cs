using Codebase.Services;
using Zenject;

namespace Codebase.Infrastructure.Installers.ProjectContext.Installers
{
    public class EnemyServicesInstaller : Installer<EnemyServicesInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyDataService>()
                .AsSingle();
        }
    }
}