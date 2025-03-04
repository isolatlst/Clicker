using System;
using System.Collections.Generic;
using Codebase.FX;
using Newtonsoft.Json;

namespace Codebase.Data.Settings
{
    [Serializable]
    public class SettingsConfig
    {
        public Dictionary<FxTypes, bool> Fxes { get; private set; }

        public SettingsConfig()
        {
            Fxes = new()
            {
                { FxTypes.Ambient, false },
                { FxTypes.ClickAudio, false },
                { FxTypes.Haptic, false },
            };
        }

        [JsonConstructor]
        public SettingsConfig(Dictionary<FxTypes, bool> fxes)
        {
            Fxes = fxes;
        }

        public override string ToString()
            => $"Ambient: {Fxes[FxTypes.Ambient]} " +
               $"Clickable: {Fxes[FxTypes.ClickAudio]} " +
               $"Haptic: {Fxes[FxTypes.Haptic]}";
    }
}