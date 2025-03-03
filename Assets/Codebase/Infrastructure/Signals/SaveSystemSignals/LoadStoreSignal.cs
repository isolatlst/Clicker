namespace Codebase.Infrastructure.Signals.SaveSystemSignals
{
    public struct LoadStoreSignal
    {
        public readonly int DamageLevel;
        public readonly int PeriodicDamageLevel;

        public LoadStoreSignal(int damageLevel, int periodicDamageLevel)
        {
            DamageLevel = damageLevel;
            PeriodicDamageLevel = periodicDamageLevel;
        }
    }
}