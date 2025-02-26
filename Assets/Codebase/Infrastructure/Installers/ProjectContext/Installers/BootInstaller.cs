using Codebase.Game;
using Zenject;

namespace Codebase.Infrastructure.Installers.ProjectContext.Installers
{
    public class BootInstaller : Installer<BootInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<GameResourceLoader>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}