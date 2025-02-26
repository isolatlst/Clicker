using System;
using Newtonsoft.Json;

namespace Codebase.Data.Player
{
    [Serializable]
    public sealed class AttackStats
    {
        public int Damage { get; private set; }
        public int PeriodicDamage { get; private set; }

        public AttackStats()
        {
            Damage = 1;
            PeriodicDamage = default;
        }

        [JsonConstructor]
        public AttackStats(int damage, int periodicDamage)
        {
            Damage = damage;
            PeriodicDamage = periodicDamage;
        }

        public override string ToString()
            => $"Damage: {Damage}, PeriodicDamage: {PeriodicDamage}";
    }
}