using System;
using Codebase.Core.Player;
using Codebase.Core.Wallet;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.Attack;
using Codebase.Infrastructure.Signals.Store;
using Zenject;

namespace Codebase.Core.Store
{
    public class Store : IInitializable, IDisposable
    {
        private PlayerAttackModel _attackModel;
        private WalletModel _walletModel;

        [Inject]
        public void Construct(PlayerAttackModel attackModel, WalletModel walletModel)
        {
            _attackModel = attackModel;
            _walletModel = walletModel;
        }

        public void Initialize()
        {
            SignalBus.Subscribe<TryBuySignal>(BuyUpgrade);
        }

        private void BuyUpgrade(TryBuySignal signal)
        {
            if (_walletModel.TrySpendCoins(signal.Price))
            {
                var newDamage = signal.Type == BoostName.Damage ? signal.Bonus : _attackModel.Damage;
                var newPeriodicDamage = signal.Type == BoostName.PeriodicDamage ? signal.Bonus : _attackModel.PeriodicDamage;

                SignalBus.Fire(new SuccessfulBuySignal(signal.Type));
                SignalBus.Fire(new UpgradeAttackStatsSignal(newDamage, newPeriodicDamage));
            }
        }

        public void Dispose()
        {
            SignalBus.Unsubscribe<TryBuySignal>(BuyUpgrade);
        }
    }
}