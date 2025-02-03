using System.Collections;
using Codebase.Data.Player;
using Codebase.Data.SaveSystem;
using Codebase.Enemy;
using Codebase.Input;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Codebase.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private SaveRepository _saveRepository;
        private IInputHandler _inputHandler;
        private PlayerStats _playerStats;
        private EnemyFacade _enemy;

        #region Initialization

        [Inject]
        public void Construct(IInputHandler input, EnemyFacade enemyFacade)
        {
            _inputHandler = input;
            _enemy = enemyFacade;
        }

        private void Awake()
        {
            _playerStats = _saveRepository.Load(new PlayerStats());
        }

        private void Start()
        {
            _inputHandler.Clicked += Attack;
            StartCoroutine(PeriodicAttack());
        }

        #endregion

        private void Attack()
        {
            _enemy.Health.TakeDamage(_playerStats.Damage);
        }

        private IEnumerator PeriodicAttack()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(1f);
                _enemy.Health.TakeDamage(_playerStats.PeriodicDamage, false);
            }
        }

        private void OnDestroy()
        {
            _saveRepository.Save(_playerStats);
            _inputHandler.Clicked -= Attack;
        }
    }
}