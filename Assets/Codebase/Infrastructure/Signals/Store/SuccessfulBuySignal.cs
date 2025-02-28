using Codebase.Core.Store;

namespace Codebase.Infrastructure.Signals.Store
{
    public struct SuccessfulBuySignal
    {
        public readonly BoostName Type;

        public SuccessfulBuySignal(BoostName type)
        {
            Type = type;
        }
    }
}