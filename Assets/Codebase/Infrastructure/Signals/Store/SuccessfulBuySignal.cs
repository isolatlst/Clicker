using Codebase.Core.Store;

namespace Codebase.Infrastructure.Signals.Store
{
    public struct SuccessfulBuySignal
    {
        public readonly BoostType Type;

        public SuccessfulBuySignal(BoostType type)
        {
            Type = type;
        }
    }
}