using System;

namespace Codebase.Wallet
{
    public class Wallet
    {
        public event Action<int> CoinsChanged;
        private int _coins;

        public void AddCoins(int amount)
        {
            if (amount > 0)
            {
                _coins += amount;
                CoinsChanged?.Invoke(_coins);
            }
        }

        public bool TrySpendCoins(int amount)
        {
            if (_coins - amount > 0 && amount > 0)
            {
                _coins -= amount;
                CoinsChanged?.Invoke(_coins);
                return true;
            }

            return false;
        }
    }
}