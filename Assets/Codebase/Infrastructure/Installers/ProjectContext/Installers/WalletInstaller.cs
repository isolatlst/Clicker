using Codebase.Core.Wallet;
using Zenject;

namespace Codebase.Infrastructure.Installers.ProjectContext.Installers
{
    public class WalletInstaller : Installer<WalletInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<WalletModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}