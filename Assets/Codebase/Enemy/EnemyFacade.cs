using Codebase.Data.Enemy;
using Codebase.Health;
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
        private Image _image;
        public Health.Health Health {get; private set;}
        public int CoinsPerDeath { get; private set; }

        #region Initialization

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Init(EnemyConfig config)
        {
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
            _image.sprite = _config.Sprite;
            Health = new Health.Health(_config.Health);
            _healthController = new HealthController(Health, _healthBarView);
            _enemyAnimation = new EnemyAnimation(this);
            CoinsPerDeath = _config.CoinsPerDeath;
        }

        #endregion
    }
}