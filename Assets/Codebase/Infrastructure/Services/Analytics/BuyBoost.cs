using System.Collections.Generic;
using Codebase.Infrastructure.Signals.Store;

namespace Codebase.Infrastructure.Services.Analytics
{
    public class BuyBoost : IReportData
    {
        public void StartReport()
        {
            SignalBus.Subscribe<UpdateBoostLevelsSignal>(s =>
            {
                Amplitude.Instance.logEvent("UpgradeAttacks", new Dictionary<string, object>
                {
                    { "Damage level", s.DamageLevel },
                    { "Periodic Damage level", s.PeriodicDamageLevel }
                });
            });
        }
    }
}