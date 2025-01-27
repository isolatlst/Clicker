using Codebase.Data;
using Codebase.Services;
using UnityEngine;
using Zenject;

namespace Codebase.Enemy
{
    public class EnemyFactory
    {
        private readonly EnemyDataService _enemyDataService;

        public EnemyFactory(EnemyDataService enemyDataService)
        {
            _enemyDataService = enemyDataService;
        }
        
        public EnemyFacade Create(EnemyFacade enemyTemplate)
        {
            EnemyConfig enemyConfig = _enemyDataService.GetEnemyInfo();
            var enemyFacade = GameObject.Instantiate(enemyTemplate);
            enemyFacade.Init(enemyConfig);
            
            return enemyFacade;
        }
    }
}