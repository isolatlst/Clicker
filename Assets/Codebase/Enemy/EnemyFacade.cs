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
        private EnemyConfig _config;
        private Health _health;
        public Health Health => _health;

        #region Initialization

        public void Init(EnemyConfig config)
        {
            _config = config;
            SetupConfig();
        }

        private void SetupConfig()
        {
            GetComponent<Image>().sprite = _config.Sprite;
            _health = new Health(_config.Health);
            _healthController = new HealthController(_health, _healthBarView);
        }

        #endregion

        private void OnDestroy()
        {
             _healthController.Dispose();
        }
    }
}