using Codebase.Data.Enemy;
using Codebase.Infrastructure.Signals.Enemy;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Services
{
    public class EnemyDataService : IInitializable
    {
        private EnemyData _enemiesData;
        private int _index = 0;

        public void Initialize()
        {
            _enemiesData = Resources.Load<EnemyData>("Enemies/HandledEnemyConfig");
            SignalBus.Subscribe<LoadLevelSignal>(LoadLevel);
        }

        private void LoadLevel(LoadLevelSignal signal)
        {
            _index = signal.Index;
            SignalBus.Unsubscribe<LoadLevelSignal>(LoadLevel);
        }

        public EnemyConfig GetEnemyConfig()
        {
            if (_index == _enemiesData.EnemiesConfigs.Count - 1)
                _index = 0;

            SignalBus.Fire(new UpdateLevelSignal(_index++));

            return _enemiesData.EnemiesConfigs[_index];
        }
    }
}