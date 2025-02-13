using System;

namespace Codebase.Data.Player
{
    [Serializable]
    public sealed class WalletStats
    {
        public int Coins { get; set; }

        public WalletStats()
        {
            Coins = 0;
        }

        public WalletStats(int coins)
        {
            Coins = coins;
        }

        public override string ToString()
            => $"Coins collected: {Coins}";
    }
}