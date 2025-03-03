using System;
using Codebase.Infrastructure.Signals;
using Codebase.Infrastructure.Signals.Enemy;
using Zenject;

namespace Codebase.Infrastructure.Services
{
    public class EnemySpawnService : IInitializable, IDisposable
    {
        private readonly EnemyDataService _enemyDataService;

        public EnemySpawnService(EnemyDataService enemyDataService)
        {
            _enemyDataService = enemyDataService;
        }

        public void Initialize()
        {
            SignalBus.Subscribe<EnemyDeathSignal>(Spawn);
            
            Spawn(new EnemyDeathSignal());
        }

        private void Spawn(EnemyDeathSignal signal)
        {
            SignalBus.Fire(new SpawnEnemySignal(_enemyDataService.GetEnemyConfig()));
        }
        
        public void Dispose()
        {
            SignalBus.Unsubscribe<EnemyDeathSignal>(Spawn);
        }
    }
}