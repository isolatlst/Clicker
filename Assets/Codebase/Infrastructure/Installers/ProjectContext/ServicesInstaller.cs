using Codebase.Infrastructure.Installers.ProjectContext.Installers;
using Zenject;

namespace Codebase.Infrastructure.Installers.ProjectContext
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SaveSystemInstaller.Install(Container);
            EnemyServicesInstaller.Install(Container);
            StoreServiceInstaller.Install(Container);
            WalletInstaller.Install(Container);
            AttackInstaller.Install(Container);
            SavecheckInstaller.Install(Container);
            InputInstaller.Install(Container);

            BootInstaller.Install(Container);
        }
    }
}