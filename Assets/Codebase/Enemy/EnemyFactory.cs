using System.Threading.Tasks;
using Codebase.Data.Enemy;
using Codebase.Services;

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

        public async Task LoadData()
        {
            await _enemyDataService.LoadData();
        }

        public EnemyFacade Create()
        {
            EnemyConfig enemyConfig = _enemyDataService.GetEnemyInfo();
            _enemyTemplate.Init(enemyConfig);

            return _enemyTemplate;
        }
    }
}