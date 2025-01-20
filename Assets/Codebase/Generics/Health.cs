using System;

namespace Codebase.Generics
{
    public class Health
    {
        public event Action<int, int> HealthChanged;
        public event Action Death;
        private readonly int _maxHealth;
        private int _health;
        
        public Health(int health)
        {
            _maxHealth = health;
            _health = health;
        }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                if (_health <= damage)
                {
                    _health = 0;
                    Death?.Invoke();   
                }
                else
                {
                    _health -= damage;
                    HealthChanged?.Invoke(_health, _maxHealth);
                }
            }
        }
    }
}