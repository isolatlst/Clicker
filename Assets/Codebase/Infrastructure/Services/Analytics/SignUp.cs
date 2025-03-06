namespace Codebase.Infrastructure.Services.Analytics
{
    public class SignUp : IReportData
    {
        public void StartReport()
        {
            Amplitude.Instance.logEvent("Sign Up");
        }
    }
}