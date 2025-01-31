using Codebase.Data;
using Codebase.Generics;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Enemy
{
    public class EnemyFacade : MonoBehaviour
    {
        [SerializeField] private HealthBarView _healthBarView;
        private HealthController _healthController;
        private EnemyAnimation _enemyAnimation;
        private EnemyConfig _config;
        private Health _health;
        public Health Health => _health;

        #region Initialization

        public void Init(EnemyConfig config)
        {
            gameObject.SetActive(true); // норм? временное решение до бут сцены
            _config = config;
            DisposePrevious();
            SetupConfig();
        }

        private void DisposePrevious() // норм?
        {
            _enemyAnimation?.Dispose();
            _healthController?.Dispose();
        }

        private void SetupConfig()
        {
            GetComponent<Image>().sprite = _config.Sprite;
            _health = new Health(_config.Health);
            _healthController = new HealthController(_health, _healthBarView);
            _enemyAnimation = new EnemyAnimation(this);
        }

        #endregion
    }
}