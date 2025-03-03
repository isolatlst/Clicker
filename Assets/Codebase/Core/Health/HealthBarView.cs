using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals;
using Codebase.Infrastructure.Signals.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Core.Health
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarView : MonoBehaviour
    {
        private Slider _viewSlider;

        private void Awake()
        {
            _viewSlider = GetComponent<Slider>();
            SignalBus.Subscribe<HealthChangedSignal>(UpdateHealthBar);
            SignalBus.Subscribe<EnemyDeathSignal>(ResetHealthBar);
        }

        private void ResetHealthBar(EnemyDeathSignal signal)
        {
            _viewSlider.maxValue = 1;
        }

        private void UpdateHealthBar(HealthChangedSignal signal)
        {
            if (signal.Health > _viewSlider.maxValue)
                _viewSlider.maxValue = signal.Health;

            _viewSlider.value = signal.Health;
        }

        private void OnDestroy()
        {
            SignalBus.Unsubscribe<HealthChangedSignal>(UpdateHealthBar);
            SignalBus.Unsubscribe<EnemyDeathSignal>(ResetHealthBar);
        }
    }
}