using System;
using Codebase.Generics;
using UnityEngine;
using Zenject;

namespace Codebase.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private HealthBarView _commonEnemyHealthBar; //fixme - тупое решение прокидывать инстантиэйтнутый бар
        public event Action<Enemy> EnemySpawned;
        private EnemyFactory _enemyFactory;

        [Inject]
        public void Construct(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void Start() //удалить после добавления системы сохранений
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            var enemy = _enemyFactory.CreateEnemy(transform, _commonEnemyHealthBar);
            enemy.Death += () => HandleDeath(enemy);
            EnemySpawned?.Invoke(enemy);
        }

        private void HandleDeath(Enemy enemy)
        {
            Destroy(enemy.gameObject);
            SpawnEnemy();
        }
    }
}