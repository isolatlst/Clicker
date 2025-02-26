using Codebase.Data.Enemy;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using UnityEngine;
using Zenject;

namespace Codebase.Services
{
    public class EnemyDataService : IInitializable
    {
        private EnemyData _enemiesData;
        private int _index = 0;

        public void Initialize()
        {
            _enemiesData = Resources.Load<EnemyData>("Enemies/HandledEnemyConfig");
            SignalBus.Subscribe<LoadLevelSignal>(LoadLevel);
        }

        private void LoadLevel(LoadLevelSignal signal)
        {
            _index = signal.Index;
            SignalBus.Unsubscribe<LoadLevelSignal>(LoadLevel);
        }

        public EnemyConfig GetEnemyConfig()
        {
            if (_index == _enemiesData.EnemiesConfigs.Count)
                _index = 0;

            SignalBus.Fire(new UpdateLevelSignal(_index++));

            return _enemiesData.EnemiesConfigs[_index];
        }
    }
}

/* generator *
private const int START_HP = 5;
private const float KOEF_EXPO = 1.2f;
private const float KOEF_LINEAR = 3f;
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