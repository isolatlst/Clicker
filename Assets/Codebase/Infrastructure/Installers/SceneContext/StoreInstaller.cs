using Codebase.Core.Store;
using Zenject;

namespace Codebase.Infrastructure.Installers.SceneContext
{
    public class StoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Store>()
                .AsSingle();
        }
    }
}