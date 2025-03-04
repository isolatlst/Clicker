using System.Collections.Generic;
using Codebase.FX;

namespace Codebase.Infrastructure.Signals.Settings
{
    public struct UpdateFxSettingsSignal
    {
        public Dictionary<FxTypes, bool> FxStatuses;

        public UpdateFxSettingsSignal(Dictionary<FxTypes, bool> statuses)
        {
            FxStatuses = statuses;
        }
    }
}