namespace Codebase.Infrastructure.Signals.SaveSystemSignals
{
    public struct LoadWalletSignal
    {
        public readonly int Coins;

        public LoadWalletSignal(int coins)
        {
            Coins = coins;
        }
    }
}