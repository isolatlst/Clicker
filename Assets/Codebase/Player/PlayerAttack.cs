using System.Collections;
using Codebase.Data.Player;
using Codebase.Data.SaveSystem;
using Codebase.Enemy;
using Codebase.Input;
using TMPro;
using UnityEngine;
using Zenject;

namespace Codebase.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private SaveRepository _saveRepository;
        private IInputHandler _inputHandler;
        private AttackStats _attackStats;
        private EnemyFacade _enemy;
        
        #region Debug
        
        [SerializeField] private TMP_InputField _damage;
        [SerializeField] private TMP_InputField _periodic;

        public void Change()
        {
            int.TryParse(_damage.text, out var dmg);
            int.TryParse(_periodic.text, out var periodicDmg);
            if(dmg != 0)
                _attackStats.Damage = dmg;
            if(periodicDmg != 0)
                _attackStats.PeriodicDamage = periodicDmg;
        }
        
        #endregion
        
        #region Initialization

        [Inject]
        public void Construct(IInputHandler input, EnemyFacade enemyFacade)
        {
            _inputHandler = input;
            _enemy = enemyFacade;
        }

        private void Awake()
        {
            _attackStats = _saveRepository.Load(new AttackStats());
        }

        private void Start()
        {
            _inputHandler.Clicked += Attack;
            StartCoroutine(PeriodicAttack());
        }

        #endregion

        private void Attack()
        {
            _enemy.Health.TakeDamage(_attackStats.Damage);
        }

        private IEnumerator PeriodicAttack()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(1f);
                _enemy.Health.TakeDamage(_attackStats.PeriodicDamage, false);
            }
        }

        //TODO поменять перед билдом на закоменченое
        private void OnDestroy()
        {
            _saveRepository.Save(_attackStats);
            _inputHandler.Clicked -= Attack;
        }
        // private void OnApplicationPause(bool isPaused) 
        // {
        //     if (isPaused)
        //     {
        //         _saveRepository.Save(_playerStats);
        //         _inputHandler.Clicked -= Attack;
        //     }
        // }
    }
}