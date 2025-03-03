namespace Codebase.Infrastructure.Signals.Enemy
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