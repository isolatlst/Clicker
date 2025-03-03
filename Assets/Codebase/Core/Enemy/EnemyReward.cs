using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals;
using Codebase.Infrastructure.Signals.Enemy;
using Codebase.Infrastructure.Signals.Wallet;
using UnityEngine;

namespace Codebase.Core.Enemy
{
    public class EnemyReward : MonoBehaviour
    {
        private int _coinsPerDeath;

        private void Awake()
        {
            SignalBus.Subscribe<EnemyDeathSignal>(ApplyReward);
        }

        public void SetReward(int coinsPerDeath)
        {
            _coinsPerDeath = coinsPerDeath;
        }

        private void ApplyReward(EnemyDeathSignal signal)
        {
            SignalBus.Fire(new ApplyRewardSignal(_coinsPerDeath));
        }

        private void OnDestroy()
        {
            SignalBus.Unsubscribe<EnemyDeathSignal>(ApplyReward);
        }
    }
}