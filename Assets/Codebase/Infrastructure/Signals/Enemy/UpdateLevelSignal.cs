namespace Codebase.Infrastructure.Signals.SaveSystemSignals
{
    public struct UpdateLevelSignal
    {
        public readonly int Index;

        public UpdateLevelSignal(int index)
        {
            Index = index;
        }
    }
}