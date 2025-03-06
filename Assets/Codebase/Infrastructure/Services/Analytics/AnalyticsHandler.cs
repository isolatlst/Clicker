using UnityEngine;

namespace Codebase.Infrastructure.Services.Analytics
{
    public class AnalyticsHandler : MonoBehaviour
    {
        private IReportData _signUpReport;
        private IReportData _buyBoostReport;
        private IReportData _enemyDeath;

        private void Awake()
        {
            _signUpReport = new SignUp();
            _buyBoostReport = new BuyBoost();
            _enemyDeath = new KillEnemy();
        }

        private void Start() // should be enabled after the user confirms reporting
        {
            StartReporting();
        }

        private void StartReporting()
        {
            _signUpReport.StartReport();
            _buyBoostReport.StartReport();
            _enemyDeath.StartReport();
        }
    }
}