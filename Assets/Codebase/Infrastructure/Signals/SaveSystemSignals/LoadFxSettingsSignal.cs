using System.Collections.Generic;
using Codebase.FX;

namespace Codebase.Infrastructure.Signals.SaveSystemSignals
{
    public struct LoadFxSettingsSignal
    {
        public Dictionary<FxTypes, bool> FxStatuses;

        public LoadFxSettingsSignal(Dictionary<FxTypes, bool> statuses)
        {
            FxStatuses = statuses;
        }
    }
}