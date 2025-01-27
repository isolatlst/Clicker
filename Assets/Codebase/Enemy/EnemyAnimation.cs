using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private EnemyFacade _enemyFacade;
        private Sequence _sequence;

        private void Start()
        {
            _enemyFacade.Health.HealthChanged += TakeDamage;
        }
        
        private void TakeDamage(int damage)
        {
            if (TryGetComponent(out Image icon))
            {
                _sequence.Complete();
                _sequence = DOTween.Sequence()
                    .Append(transform.DOScale(new Vector3(0.95f, 0.95f, 0.95f), 0.2f))
                    .Join(icon.DOColor(new Color(50, 0, 0, 1f), 0.1f))
                    .Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f))
                    .Join(icon.DOColor(new Color(255, 255, 255, 1f), 0.1f));
            }
        }
        
        private void OnDestroy()
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