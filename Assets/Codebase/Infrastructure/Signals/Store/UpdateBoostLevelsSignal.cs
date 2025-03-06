namespace Codebase.Infrastructure.Signals.Store
{
    public struct UpdateBoostLevelsSignal
    {
        public readonly int DamageLevel;
        public readonly int PeriodicDamageLevel;

        public UpdateBoostLevelsSignal(int damageLevel, int periodicDamageLevel)
        {
            DamageLevel = damageLevel;
            PeriodicDamageLevel = periodicDamageLevel;
        }
    }
}