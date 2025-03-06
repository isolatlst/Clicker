using UnityEngine;

namespace Codebase.Boot
{
    public class RootSetup
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Screen.orientation = ScreenOrientation.Portrait;
            
            Amplitude amplitude = Amplitude.getInstance();
            Amplitude.Instance.setServerUrl("https://api.amplitude.com/");
            amplitude.trackSessionEvents(true);
            amplitude.init("e477aecaed2f5baf23251cf6d17d3e92");
        }
    }
}