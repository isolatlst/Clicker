namespace Codebase.Infrastructure.Signals.SaveSystemSignals
{
    public struct UpdateStoreSignal
    {
        public readonly int DamageLevel;
        public readonly int PeriodicDamageLevel;

        public UpdateStoreSignal(int damageLevel, int periodicDamageLevel)
        {
            DamageLevel = damageLevel;
            PeriodicDamageLevel = periodicDamageLevel;
        }
    }
}