using Codebase.Data;
using Codebase.Services;
using UnityEngine;

namespace Codebase.Enemy
{
    public class EnemyFactory
    {
        private readonly EnemyDataService _enemyDataService;
        private readonly EnemyFacade _enemyTemplate;

        public EnemyFactory(EnemyDataService enemyDataService, EnemyFacade enemyTemplate)
        {
            _enemyDataService = enemyDataService;
            _enemyTemplate = enemyTemplate;
        }

        public EnemyFacade CreateEnemy()
        {
            EnemyConfig enemyConfig = _enemyDataService.GetEnemyInfo();
            var enemyFacade = GameObject.Instantiate(_enemyTemplate);
            enemyFacade.Init(enemyConfig);
            
            return enemyFacade;
        }
    }
}