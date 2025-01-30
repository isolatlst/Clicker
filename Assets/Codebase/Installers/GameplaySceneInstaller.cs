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
            Debug.Log("GameplaySceneInstaller InstallBindings");
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
                .AsSingle();
        }

        private void BindEnemyFactory()
        {
            Container
                .Bind<EnemyFactory>()
                .AsSingle();
        }
    }
}