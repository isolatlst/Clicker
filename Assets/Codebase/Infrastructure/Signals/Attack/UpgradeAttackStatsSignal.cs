namespace Codebase.Infrastructure.Signals.Attack
{
    public struct UpgradeAttackStatsSignal
    {
        public readonly int Damage;
        public readonly int PeriodicDamage;

        public UpgradeAttackStatsSignal(int damage, int periodicDamage)
        {
            Damage = damage;
            PeriodicDamage = periodicDamage;
        }
    }
}