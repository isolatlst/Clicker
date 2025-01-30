using System.Collections.Generic;
using Codebase.Data;
using UnityEngine;

namespace Codebase.Services
{
    public class EnemyDataService
    {
        private readonly List<EnemyConfig> _enemiesData;
        private int _index = 0;

        public EnemyDataService()
        {
            EnemyData data = Resources.Load<EnemyData>("Enemies/Enemy Data");
            _enemiesData = data.EnemyConfigs;
        }

        public EnemyConfig GetEnemyInfo()
        {
            if(_index == _enemiesData.Count)
                _index = 0;
            
            return _enemiesData[_index++];
        }
    }
}