namespace Codebase.Infrastructure.Signals.Enemy
{
    public struct HealthChangedSignal
    {
        public readonly int Health;
        public readonly bool IsAnimated;

        public HealthChangedSignal(int health, bool isAnimated)
        {
            Health = health;
            IsAnimated = isAnimated;
        }
    }
}