using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals;

namespace Codebase.Core.Health
{
    public class Health
    {
        private int _health;

        public void SetHealth(int health = default)
        {
            _health = health;
            SignalBus.Fire(new HealthChangedSignal(_health, false));
        }

        public void TakeDamage(int damage, bool isAnimated = true)
        {
            if (damage > 0)
            {
                if (_health <= damage)
                {
                    _health = 0;
                    SignalBus.Fire<EnemyDeathSignal>();
                }
                else
                {
                    _health -= damage;
                    SignalBus.Fire(new HealthChangedSignal(_health, isAnimated));
                }
            }
        }
    }
}