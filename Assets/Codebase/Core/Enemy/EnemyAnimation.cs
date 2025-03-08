using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.Enemy;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Core.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Image _enemyView;
        private Sequence _sequence;

        private void Awake()
        {
            SignalBus.Subscribe<HealthChangedSignal>(TakeDamage);
        }

        private void TakeDamage(HealthChangedSignal signal)
        {
            if (!signal.IsAnimated)
                return;

            _sequence.Complete();
            _sequence = DOTween.Sequence()
                .Append(_enemyView.transform.DOScale(new Vector3(0.95f, 0.95f, 0.95f), 0.2f))
                .Join(_enemyView.DOColor(new Color(50, 0, 0, 1f), 0.1f))
                .Append(_enemyView.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f))
                .Join(_enemyView.DOColor(new Color(255, 255, 255, 1f), 0.1f));
        }

        private void OnDestroy()
        {
            if (_sequence != null)
            {
                _sequence.Complete();
                _sequence = null;
            }

            SignalBus.Unsubscribe<HealthChangedSignal>(TakeDamage);
        }
    }
}