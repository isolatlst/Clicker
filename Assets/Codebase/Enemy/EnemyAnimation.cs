using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Enemy
{
    public class EnemyAnimation
    {
        private readonly EnemyFacade _enemyFacade;
        private Sequence _sequence;

        public EnemyAnimation(EnemyFacade enemyFacade)
        {
            _enemyFacade = enemyFacade;
            _enemyFacade.Health.HealthChanged += TakeDamage;
        }

        private void TakeDamage(int damage)
        {
            if (_enemyFacade.TryGetComponent(out Image icon))
            {
                _sequence.Complete();
                _sequence = DOTween.Sequence()
                    .Append(_enemyFacade.transform.DOScale(new Vector3(0.95f, 0.95f, 0.95f), 0.2f))
                    .Join(icon.DOColor(new Color(50, 0, 0, 1f), 0.1f))
                    .Append(_enemyFacade.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f))
                    .Join(icon.DOColor(new Color(255, 255, 255, 1f), 0.1f));
            }
        }
        
        public void Dispose()
        {
            if (_sequence != null)
            {
                _sequence.Complete();
                _sequence = null;
            }
            
            _enemyFacade.Health.HealthChanged -= TakeDamage;
        }
    }
}