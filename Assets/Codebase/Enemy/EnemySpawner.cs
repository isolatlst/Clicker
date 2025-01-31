using UnityEngine;
using Zenject;

namespace Codebase.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyFactory _enemyFactory;
        private EnemyFacade _currentEnemy;

        [Inject]
        public void Construct(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private async void Start()
        {
            await _enemyFactory.LoadData();
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            _currentEnemy = _enemyFactory.Create();
            _currentEnemy.Health.Death += OnEnemyDeath;
        }

        private void OnEnemyDeath()
        {
            _currentEnemy.Health.Death -= OnEnemyDeath;
            SpawnEnemy();
        }
    }
}