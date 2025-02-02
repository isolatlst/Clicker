using System.Collections.Generic;
using System.Threading.Tasks;
using Codebase.Data;
using Codebase.Data.Enemy;
using UnityEngine;

namespace Codebase.Services
{
    public class EnemyDataService
    {
        private List<EnemyConfig> _enemiesData;
        private int _index = 0;

        public async Task LoadData() // норм?
        {
            await Task.Yield();

            var data = Resources.Load<EnemyData>("Enemies/Enemy Data");
            _enemiesData = data.EnemiesConfigs;
        }

        public EnemyConfig GetEnemyInfo()
        {
            if (_index == _enemiesData.Count)
                _index = 0;

            return _enemiesData[_index++];
        }
    }
}