﻿using System;

namespace Codebase.Data.Player
{
    [Serializable]
    public sealed class PlayerStats
    {
        public int Damage { get; set; }
        public int PeriodicDamage { get; set; }

        public PlayerStats()
        {
            Damage = 1;
            PeriodicDamage = 0;
        }

        public PlayerStats(int damage, int periodicDamage)
        {
            Damage = damage;
            PeriodicDamage = periodicDamage;
        }

        public override string ToString()
            => $"Damage: {Damage}, PeriodicDamage: {PeriodicDamage}";
    }
}