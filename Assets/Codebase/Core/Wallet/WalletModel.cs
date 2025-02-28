using System;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using Codebase.Infrastructure.Signals.Wallet;
using Zenject;

namespace Codebase.Core.Wallet
{
    public class WalletModel : IInitializable, IDisposable
    {
        private int _coins;

        public void Initialize()
        {
            SignalBus.Subscribe<ApplyRewardSignal>(AddCoins);
            SignalBus.Subscribe<LoadWalletSignal>(LoadCoins);
        }

        private void LoadCoins(LoadWalletSignal signal)
        {
            AddCoins(new ApplyRewardSignal(signal.Coins));
            SignalBus.Unsubscribe<LoadWalletSignal>(LoadCoins);
        }

        private void AddCoins(ApplyRewardSignal signal)
        {
            if (signal.CoinsReward > 0)
            {
                _coins += signal.CoinsReward;
                SignalBus.Fire(new CoinsChangedSignal(_coins));
            }
        }

        public bool TrySpendCoins(int amount)
        {
            if (_coins - amount >= 0 && amount > 0)
            {
                _coins -= amount;
                SignalBus.Fire(new CoinsChangedSignal(_coins));
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            SignalBus.Unsubscribe<ApplyRewardSignal>(AddCoins);
        }
    }
}