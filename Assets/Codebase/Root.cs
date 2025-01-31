using UnityEngine;

namespace Codebase
{
    public class Root
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] // норм?
        private static void Initialize()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}