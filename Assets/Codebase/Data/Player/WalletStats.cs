using System;
using Newtonsoft.Json;

namespace Codebase.Data.Player
{
    [Serializable]
    public sealed class WalletStats
    {
        public int Coins { get; private set; }

        public WalletStats()
        {
            Coins = default;
        }

        [JsonConstructor]
        public WalletStats(int coins)
        {
            Coins = coins;
        }

        public override string ToString()
            => $"Coins in wallet: {Coins}";
    }
}