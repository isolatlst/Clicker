using Codebase.Core.Player;
using Zenject;

namespace Codebase.Infrastructure.Installers.ProjectContext.Installers
{
    public class AttackInstaller : Installer<AttackInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerAttackModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}