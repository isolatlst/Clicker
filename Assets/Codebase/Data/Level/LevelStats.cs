using System;
using Newtonsoft.Json;

namespace Codebase.Data.Level
{
    [Serializable]
    public sealed class LevelStats
    {
        public int Index { get; private set; }

        public LevelStats()
        {
            Index = default;
        }
        
        [JsonConstructor]
        public LevelStats(int index)
        {
            Index = index;
        }

        public override string ToString()
            => $"Level of enemy: {Index}";
    }
}