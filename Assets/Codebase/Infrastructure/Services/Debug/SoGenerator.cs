using UnityEngine;

namespace Codebase.Infrastructure.Services.Debug
{
    public class SoGenerator : MonoBehaviour
    {
        private const int START_HP = 5;
        private const int BASE_COST = 10;
        private const int BASE_COST_OVER = 25;
        private const float BASE_DAMAGE_KOEF = 2.45f;
        private const float KOEF_EXPO = 1.2f;
        private const float KOEF_LINEAR = 3f;

        
        /* generator for Store Data
            StoreData asset = ScriptableObject.CreateInstance<StoreData>();
            asset.DamagePrice = new List<StoreItemConfig>();
            asset.PeriodicDamagePrice = new List<StoreItemConfig>();

            for (var i = 0; i < 20; i++)
            {
                var dmgItem = new StoreItemConfig
                {
                    Level = i,
                    Bonus = (int)Math.Floor(BASE_DAMAGE_KOEF * Math.Pow(KOEF_EXPO, i - 1) + KOEF_LINEAR),
                    Price = (int)Math.Floor(BASE_COST + Math.Pow(i, BASE_DAMAGE_KOEF))
                };
                asset.DamagePrice.Add(dmgItem);

                var perDmgItem = new StoreItemConfig
                {
                    Level = i,
                    Bonus = (int)Math.Floor(KOEF_EXPO * Math.Pow(KOEF_EXPO, i - 2) + KOEF_LINEAR),
                    Price = (int)Math.Floor(BASE_COST_OVER + Math.Pow(i, KOEF_LINEAR))
                };
                asset.PeriodicDamagePrice.Add(perDmgItem);
            }

            AssetDatabase.CreateAsset(asset, "Assets/HandledStoreConfig.asset");
            AssetDatabase.SaveAssets();*/

        /* generator for Enemies Data*


        private Sprite[] _spritesAtlas;

            _spritesAtlas = Resources.LoadAll<Sprite>("Enemies/Sprites");

            EnemyData asset = ScriptableObject.CreateInstance<EnemyData>();
            asset.EnemiesConfigs = new List<EnemyConfig>();

            foreach (var sprite in _spritesAtlas)
            {
                var config = new EnemyConfig
                    {
                        Sprite = sprite,
                        Health = (int)Math.Floor(START_HP * Math.Pow(KOEF_EXPO, (_index + 1)) + KOEF_LINEAR * Math.Pow(KOEF_EXPO, 2))
                    };

                config.CoinsPerDeath = (int)Mathf.Floor(config.Health / 5);
                asset.EnemiesConfigs.Add(config);
                _index++;
            }

            AssetDatabase.CreateAsset(asset, "Assets/HandledEnemyConfig.asset");
            AssetDatabase.SaveAssets();
         */
    }
}