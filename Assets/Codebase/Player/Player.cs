using Codebase.Enemy;
using Codebase.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _spawner;
        private IInputHandler _inputHandler;

        [Inject]
        public void Construct(IInputHandler input)
        {
            _inputHandler = input;
        }

        private void Awake()
        {
            Debug.Log("Player Awake");
            _inputHandler.Clicked += Attack;
        }

        private void Attack()
        {
            if (_spawner.CurrentEnemy != null)
                _spawner.CurrentEnemy.Health.TakeDamage(1);
        }

        private void OnDestroy()
        {
            _inputHandler.Clicked -= Attack;
        }
    }
}