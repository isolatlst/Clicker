using UnityEngine;

namespace Codebase.Boot
{
    public class Root
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Screen.orientation = ScreenOrientation.Portrait;


            Amplitude amplitude = Amplitude.getInstance();
            amplitude.init("e477aecaed2f5baf23251cf6d17d3e92");

#if UNITY_EDITOR
            System.Type deviceSimulatorType =
                System.Type.GetType("UnityEditor.DeviceSimulation.Simulator, UnityEditor.DeviceSimulator");
            if (deviceSimulatorType != null)
                Amplitude.Instance.setServerUrl("https://api.amplitude.com/");
#endif
            amplitude.logEvent("Sign Up");
        }
    }
}