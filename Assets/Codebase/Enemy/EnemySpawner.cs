using UnityEngine;
using Zenject;

namespace Codebase.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFacade _enemyTemplate;
        private EnemyFactory _enemyFactory;
        public EnemyFacade CurrentEnemy { get; private set; }
        
        [Inject]
        public void Construct (EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void Start()
        {
            SpawnEnemy();
        }
        
        private void SpawnEnemy()
        {
            CurrentEnemy = _enemyFactory.Create(_enemyTemplate);
            CurrentEnemy.transform.SetParent(transform, false);
            
            CurrentEnemy.Health.Death += OnEnemyDeath;
        }
        
        private void OnEnemyDeath()
        {
            CurrentEnemy.Health.Death -= OnEnemyDeath;
            Destroy(CurrentEnemy.gameObject);
            SpawnEnemy();
        }
    }
}