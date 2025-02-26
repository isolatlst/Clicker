namespace Codebase.Infrastructure.Signals.SaveSystemSignals
{
    public struct LoadAttackSignal
    {
        public readonly int Damage;
        public readonly int PeriodicDamage;

        public LoadAttackSignal(int damage, int periodicDamage)
        {
            Damage = damage;
            PeriodicDamage = periodicDamage;
        }
    }
}