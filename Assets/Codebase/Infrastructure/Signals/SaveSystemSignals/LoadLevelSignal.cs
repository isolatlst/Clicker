namespace Codebase.Infrastructure.Signals.SaveSystemSignals
{
    public struct LoadLevelSignal
    {
        public readonly int Index;

        public LoadLevelSignal(int index)
        {
            Index = index;
        }
    }
}