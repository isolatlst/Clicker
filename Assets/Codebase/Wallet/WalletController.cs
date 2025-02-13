using System;

namespace Codebase.Wallet
{
    public class WalletController : IDisposable
    {
        private Wallet _wallet;
        private WalletView _walletView;
        
        public WalletController(Wallet wallet, WalletView walletView)
        {
            _wallet = wallet;
            _walletView = walletView;

            _wallet.CoinsChanged += OnCoinsChanged;
        }

        private void OnCoinsChanged(int amount)
        {
            _walletView.UpdateCoinsView(amount);
        }

        public void Dispose()
        {
            _wallet.CoinsChanged -= OnCoinsChanged;
        }
    }
}