using System.Linq;
using Codebase.ScriptableObjects;
using UnityEngine;

namespace Codebase.Services
{
    public class EnemyDataService
    {
        private EnemyInfo[] _enemiesInfo;
        private int _index = 0;

        public EnemyDataService()
        {
            _enemiesInfo = Resources.LoadAll<EnemyInfo>("Enemy").OrderBy(data  => data.Id).ToArray();
        }

        public EnemyInfo GetRandomEnemyInfo()
        {
            var rIndex = Random.Range(0, _enemiesInfo.Length);
            return _enemiesInfo[rIndex];
        }

        public EnemyInfo GetEnemyInfo()
        {
            if (_index == _enemiesInfo.Length)
                _index = 0;

            Debug.Log(_enemiesInfo[_index]);
            
            return _enemiesInfo[_index++];
        }
    }
}