namespace Codebase.Infrastructure.Signals.Store
{
    public struct UpdateLevelsSignal
    {
        public readonly int DamageLevel;
        public readonly int PeriodicDamageLevel;

        public UpdateLevelsSignal(int damageLevel, int periodicDamageLevel)
        {
            DamageLevel = damageLevel;
            PeriodicDamageLevel = periodicDamageLevel;
        }
    }
}