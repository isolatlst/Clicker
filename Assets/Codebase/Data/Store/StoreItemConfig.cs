using System;
using UnityEngine;

namespace Codebase.Data.Store
{
    [Serializable]
    public sealed class StoreItemConfig
    {
        [field: SerializeField] public int Level { get; private set; }
        [field: SerializeField] public int Bonus { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
    }
}