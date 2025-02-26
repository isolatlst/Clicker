using Codebase.Enemy;
using Codebase.Services;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Installers.SceneContext
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyFacade _enemyTemplate;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyFacade>()
                .FromInstance(_enemyTemplate)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<EnemySpawnService>()
                .AsSingle();
        }
    }
}