using System;
using Newtonsoft.Json;

namespace Codebase.Data.Store
{
    [Serializable]
    public sealed class StoreStats
    {
        public int DamageLevel { get; private set; }
        public int PeriodicDamageLevel { get; private set; }
        
        public StoreStats()
        {
            DamageLevel = default;
            PeriodicDamageLevel = default;
        }
        
        [JsonConstructor]
        public StoreStats(int damageLevel, int periodicDamageLevel)
        {
            DamageLevel = damageLevel;
            PeriodicDamageLevel = periodicDamageLevel;
        }

        public override string ToString()
            => $"Level of damage: {DamageLevel}, level of per. damage: {PeriodicDamageLevel}";
    }
}