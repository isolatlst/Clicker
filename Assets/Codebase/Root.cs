using UnityEngine;

namespace Codebase
{
    public class Root
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 90;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Screen.orientation  = ScreenOrientation.Portrait;
        }
    }
}