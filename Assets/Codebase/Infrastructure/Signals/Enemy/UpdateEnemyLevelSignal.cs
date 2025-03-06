namespace Codebase.Infrastructure.Signals.Enemy
{
    public struct UpdateEnemyLevelSignal
    {
        public readonly int Index;

        public UpdateEnemyLevelSignal(int index)
        {
            Index = index;
        }
    }
}