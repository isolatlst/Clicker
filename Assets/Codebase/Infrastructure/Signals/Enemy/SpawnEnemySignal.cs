using Codebase.Data.Enemy;

namespace Codebase.Infrastructure.Signals.Enemy
{
    public struct SpawnEnemySignal
    {
        public readonly EnemyConfig Config;

        public SpawnEnemySignal(EnemyConfig config)
        {
            Config = config;
        }
    }
}