using Codebase.Generics;
using Codebase.ScriptableObjects;
using Codebase.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Enemy
{
    public class EnemyFactory
    {
        private EnemyDataService _enemyDataService;
        
        public EnemyFactory (EnemyDataService enemyDataService)
        {
            _enemyDataService = enemyDataService;
        }

        public Enemy CreateEnemy(Transform parent, HealthBarView commonHealthBar)
        {
            EnemyInfo enemyInfo = _enemyDataService.GetEnemyInfo();
            var enemy = new GameObject("Enemy");
            var enemyComponent = SetupEnemyComponent(enemy);
            var imageComponent = SetupSprite(enemy, enemyInfo.Sprite);

            SetupHealth(enemyComponent, commonHealthBar, enemyInfo.Health);

            var rectTransform = imageComponent.GetComponent<RectTransform>();
            rectTransform.SetParent(parent);
            ConfigurePosition(rectTransform);
            
            return enemyComponent;
        }

        private Image SetupSprite(GameObject enemy, Sprite sprite)
        {
            var image = enemy.AddComponent<Image>();
            image.sprite = sprite;
            image.preserveAspect = true;

            return image;
        }

        private Enemy SetupEnemyComponent(GameObject enemy) => enemy.AddComponent<Enemy>();

        private void SetupHealth(Enemy enemy, HealthBarView enemyHealthBar, int healthValue)
        {
            var health = new Health(healthValue);
            enemy.Init(health, enemyHealthBar);
        }

        private void ConfigurePosition(RectTransform rectTransform)
        {
            rectTransform.anchoredPosition3D = Vector3.zero;
            rectTransform.sizeDelta = new Vector2(500, 500);
            rectTransform.localScale = Vector3.one;
            rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}