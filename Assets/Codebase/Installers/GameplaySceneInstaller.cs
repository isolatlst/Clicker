using Codebase.Enemy;
using Codebase.Generics;
using Codebase.Input;
using Codebase.Services;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
            BindEnemyDataService();
        }
        
        private void BindInput()
        {
            if (Application.isMobilePlatform)
                Container.Bind<IInputHandler>().To<MobileInputHandler>().AsSingle();
            else
                Container.Bind<IInputHandler>().To<PCInputHandler>().AsSingle();
        }

        private void BindEnemyDataService()
        {
            Container.Bind<EnemyDataService>().AsSingle();
            Container.Bind<EnemyFactory>().AsSingle();
        }
    }
}