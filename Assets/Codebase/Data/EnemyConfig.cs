using System;
using UnityEngine;

namespace Codebase.Data
{
    [Serializable]
    public sealed class EnemyConfig
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}