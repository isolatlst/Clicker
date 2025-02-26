namespace Codebase.Infrastructure.Signals.Wallet
{
    public struct CoinsChangedSignal
    {
        public readonly int Coins;

        public CoinsChangedSignal(int coins)
        {
            Coins = coins;
        }
    }
}