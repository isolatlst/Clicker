using System.Collections;
using Codebase.Enemy;
using Codebase.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        private IInputHandler _inputHandler;
        private Enemy.Enemy _currentEnemy;


        [Inject]
        public void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void Awake()
        {
            _enemySpawner.EnemySpawned += SetCurrentEnemy;
            _inputHandler.Clicked += Attack;
        }

        private void Update()
        {
            _inputHandler.LocalUpdate();
        }

        private void SetCurrentEnemy(Enemy.Enemy enemy)
        {
            _currentEnemy = enemy;
        }

        private void Attack()
        {
            if (_currentEnemy != null)
                _currentEnemy.TakeDamage(1);
        }

        private void OnDestroy()
        {
            _enemySpawner.EnemySpawned -= SetCurrentEnemy;
            _inputHandler.Clicked -= Attack;
        }
    }
}