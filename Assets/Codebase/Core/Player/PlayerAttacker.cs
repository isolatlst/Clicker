using System.Collections;
using Codebase.Core.Enemy;
using Codebase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Core.Player
{
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private PlayerAttackAnimation _animation;
        private IInputHandler _inputHandler;
        private PlayerAttackModel _attackStats;
        private EnemyFacade _enemy;

        [Inject]
        public void Construct(IInputHandler input, PlayerAttackModel stats, EnemyFacade enemy)
        {
            _inputHandler = input;
            _attackStats = stats;
            _enemy = enemy;
        }

        private void Awake()
        {
            _inputHandler.Clicked += Attack;
            StartCoroutine(PeriodicAttack());
        }

        private void Attack()
        {
            _enemy.Health.TakeDamage(_attackStats.Damage);
            _animation.Play(_attackStats.Damage);
        }

        private IEnumerator PeriodicAttack()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(1f);
                _enemy.Health.TakeDamage(_attackStats.PeriodicDamage, false);
            }
        }

        private void OnDestroy()
        {
            _inputHandler.Clicked -= Attack;
        }
    }
}