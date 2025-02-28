using Codebase.Core.Store;

namespace Codebase.Infrastructure.Signals.Store
{
    public struct TryBuySignal
    {
        public readonly BoostName Type;
        public readonly int Price;
        public readonly int Bonus;

        public TryBuySignal(BoostName type, int price,  int bonus)
        {
            Type = type;
            Price = price;
            Bonus = bonus;
        }
    }
}