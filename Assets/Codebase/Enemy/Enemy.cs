using System;
using Codebase.Generics;
using UnityEngine;

namespace Codebase.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public event Action Death; //сомнительное решение
        private Health _health;
        private HealthBarView _healthBarView;
        private HealthController _healthController;
        
        public void Init(Health health, HealthBarView enemyHealthBar)
        {
            _health = health;
            _healthBarView = enemyHealthBar;
            _healthController = new HealthController(_health, _healthBarView);
            
            _health.Death += HandleDeath;
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            //play animation
        }

        private void HandleDeath() //сомнительное решение
        {
            Death?.Invoke();
        }

        private void OnDestroy()
        {
            _healthController.Dispose();
        }
    }
}