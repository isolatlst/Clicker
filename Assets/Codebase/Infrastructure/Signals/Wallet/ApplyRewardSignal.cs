namespace Codebase.Infrastructure.Signals.Wallet
{
    public struct ApplyRewardSignal
    {
        public readonly int CoinsReward;

        public ApplyRewardSignal(int coins)
        {
            CoinsReward = coins;
        }
    }
}