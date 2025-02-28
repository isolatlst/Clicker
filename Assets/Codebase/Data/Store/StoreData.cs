using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Data.Store
{
    [CreateAssetMenu(menuName = "Store/Create Store Data", fileName = "Store Data")]
    public class StoreData : ScriptableObject
    {
        [field: SerializeField] public List<StoreItemConfig> DamagePrice { get; private set; }
        [field: SerializeField] public List<StoreItemConfig> PeriodicDamagePrice { get; private set; }
    }
}