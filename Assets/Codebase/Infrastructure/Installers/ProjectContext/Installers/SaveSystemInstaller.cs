using Codebase.Data.SaveSystem;
using Zenject;

namespace Codebase.Infrastructure.Installers.ProjectContext.Installers
{
    public class SaveSystemInstaller : Installer<SaveSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<FileSaveSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<SaveRepository>()
                .AsSingle()
                .NonLazy();
        }
    }
}