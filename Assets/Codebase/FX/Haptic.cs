using CandyCoded.HapticFeedback;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.Enemy;
using UnityEngine;

namespace Codebase.FX
{
    public class Haptic : MonoBehaviour, IFxControlable
    {
        private bool _isShouldPlay;

        private void Awake()
        {
            SignalBus.Subscribe<EnemyDeathSignal>(PlayEffect);
        }

        private void PlayEffect(EnemyDeathSignal signal)
        {
            if (_isShouldPlay)
            {
                HapticFeedback.LightFeedback();
            }
        }

        public void On()
        {
            _isShouldPlay = true;
        }

        public void Off()
        {
            _isShouldPlay = false;
        }

        private void OnDestroy()
        {
            SignalBus.Unsubscribe<EnemyDeathSignal>(PlayEffect);
        }
    }
}