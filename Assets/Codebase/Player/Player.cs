using System.Collections;
using Codebase.Data.Player;
using Codebase.Data.SaveSystem;
using Codebase.Enemy;
using Codebase.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private int periodicdamage;
        private IInputHandler _inputHandler;
        private PlayerStats _playerStats;
        private ISaveSystem _saveSystem;
        private EnemyFacade _enemy;

        #region Initialization

        [Inject]
        public void Construct(IInputHandler input, EnemyFacade enemyFacade, ISaveSystem saveSystem)
        {
            _inputHandler = input;
            _enemy = enemyFacade;
            _saveSystem = saveSystem;
        }

        private void Awake()
        {
            _playerStats = _saveSystem.Load<PlayerStats>(new PlayerStats());
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
            _playerStats.Damage = damage;
            _playerStats.PeriodicDamage = periodicdamage;
            
            _saveSystem.Save(_playerStats);
            _inputHandler.Clicked -= Attack;
        }
    }
}