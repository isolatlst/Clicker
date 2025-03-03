using Codebase.Core.Health;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals;
using Codebase.Infrastructure.Signals.Enemy;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebase.Core.Enemy
{
    public class EnemyFacade : MonoBehaviour, IInitializable
    {
        public Health.Health Health { get; private set; }
        [SerializeField] private HealthBarView _healthBarView;
        private EnemyReward _reward;
        private Image _image;

        public void Initialize()
        {
            SignalBus.Subscribe<SpawnEnemySignal>(SetupConfig);
            
            _image = GetComponent<Image>();
            _reward = GetComponent<EnemyReward>();
            Health = new Health.Health();
        }

        private void SetupConfig(SpawnEnemySignal signal)
        {
            _image.sprite = signal.Config.Sprite;
            Health.SetHealth(signal.Config.Health);
            _reward.SetReward(signal.Config.CoinsPerDeath);
        }

        private void OnDestroy()
        {
            SignalBus.Unsubscribe<SpawnEnemySignal>(SetupConfig);
        }
    }
}