using Codebase.Enemy;
using Codebase.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Player
{
    public class Player : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private EnemyFacade _enemy;

        [Inject]
        public void Construct(IInputHandler input, EnemyFacade enemyFacade)
        {
            _inputHandler = input;
            _enemy = enemyFacade;
        }

        private void Awake()
        {
            _inputHandler.Clicked += Attack;
        }

        private void Attack()
        {
            _enemy.Health.TakeDamage(1);
        }

        private void OnDestroy()
        {
            _inputHandler.Clicked -= Attack;
        }
    }
}