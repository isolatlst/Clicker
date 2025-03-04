using Codebase.FX;

namespace Codebase.Infrastructure.Signals.Settings
{
    public struct SwapFxStatusSignal
    {
        public FxTypes Type;
        public bool IsEnabled;

        public SwapFxStatusSignal(FxTypes type, bool isEnabled)
        {
            Type = type;
            IsEnabled = isEnabled;
        }
    }
}