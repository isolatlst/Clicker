using Codebase.Enemy;
using Codebase.Input;
using Codebase.Services;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private EnemyFacade _enemyTemplate;

        public override void InstallBindings()
        {
            BindInput();
            BindEnemyDataService();
            BindEnemyFactory();
        }

        private void BindInput()
        {
            if (Application.isMobilePlatform)
                Container.BindInterfacesAndSelfTo<MobileInputHandler>().AsSingle();
            else
                Container.BindInterfacesAndSelfTo<PCInputHandler>().AsSingle();
        }

        private void BindEnemyDataService()
        {
            Container
                .Bind<EnemyDataService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindEnemyFactory()
        {
            Container
                .Bind<EnemyFacade>()
                .FromInstance(_enemyTemplate)
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<EnemyFactory>()
                .AsSingle()
                .NonLazy();

        }
    }
}