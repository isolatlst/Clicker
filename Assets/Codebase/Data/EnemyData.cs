using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Data
{
    [CreateAssetMenu(menuName = "Enemies/Create Enemy Data", fileName = "Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public List<EnemyConfig> EnemyConfigs;
    }
}