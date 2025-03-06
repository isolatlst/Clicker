using System.Collections.Generic;
using Codebase.Infrastructure.Signals.Enemy;

namespace Codebase.Infrastructure.Services.Analytics
{
    public class KillEnemy : IReportData
    {
        public void StartReport()
        {
            SignalBus.Subscribe<UpdateEnemyLevelSignal>(s =>
            {
                Amplitude.Instance.logEvent("Completed level", new Dictionary<string, object>
                {
                    { "Level", s.Index }
                });
            });
        }
    }
}