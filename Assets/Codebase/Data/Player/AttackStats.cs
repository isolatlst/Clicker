using System;

namespace Codebase.Data.Player
{
    [Serializable]
    public sealed class AttackStats
    {
        public int Damage { get; set; }
        public int PeriodicDamage { get; set; }

        public AttackStats()
        {
            Damage = 1;
            PeriodicDamage = 0;
        }

        public AttackStats(int damage, int periodicDamage)
        {
            Damage = damage;
            PeriodicDamage = periodicDamage;
        }

        public override string ToString()
            => $"Damage: {Damage}, PeriodicDamage: {PeriodicDamage}";
    }
}