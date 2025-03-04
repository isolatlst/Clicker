using System;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.Attack;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using Zenject;

namespace Codebase.Core.Player
{
    public class PlayerAttackModel : IInitializable, IDisposable
    {
        public int Damage { get; private set; }
        public int PeriodicDamage { get; private set; }

        public void Initialize()
        {
            SignalBus.Subscribe<UpgradeAttackStatsSignal>(UpdateAttackStats);
            SignalBus.Subscribe<LoadAttackSignal>(LoadAttackStats);
        }

        private void LoadAttackStats(LoadAttackSignal signal)
        {
            UpdateAttackStats(new UpgradeAttackStatsSignal(signal.Damage, signal.PeriodicDamage));
            SignalBus.Unsubscribe<LoadAttackSignal>(LoadAttackStats);
        }

        private void UpdateAttackStats(UpgradeAttackStatsSignal signal)
        {
            if (signal.Damage > 0)
                Damage = signal.Damage;
            if (signal.PeriodicDamage > 0)
                PeriodicDamage = signal.PeriodicDamage;
        }

        public void Dispose()
        {
            SignalBus.Unsubscribe<UpgradeAttackStatsSignal>(UpdateAttackStats);
        }
    }
}