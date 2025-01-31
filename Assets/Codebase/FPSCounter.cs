using System.Collections;
using TMPro;
using UnityEngine;

namespace Codebase
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _FPSText;
        [SerializeField] private TextMeshProUGUI _bestFPSText;
        [SerializeField] private TextMeshProUGUI _lowestFPSText;
        [SerializeField] private TextMeshProUGUI _refreshRateText;

        private int _bestFPS;
        private int _lowestFPS = int.MaxValue;
        private float _fpsSum;
        private int _frameCount;
        private bool _isGameLoaded;

        private void Start()
        {
            StartCoroutine(UpdateFPSView());
            _refreshRateText.text = $"RR, Hz: {Screen.currentResolution.refreshRate}";
        }

        private IEnumerator UpdateFPSView()
        {
            while (gameObject.activeSelf)
            {
                yield return new WaitForSecondsRealtime(1.0f);

                var avgFPS = (int)(_fpsSum / _frameCount);
                _FPSText.text = $"FPS: {avgFPS}";
                _bestFPSText.text = $"Best: {_bestFPS}";
                _lowestFPSText.text = $"Low: {_lowestFPS}";

                _fpsSum = 0;
                _frameCount = 0;
                _isGameLoaded = true;
            }
        }

        private void Update()
        {
            var currentFPS = 1f / Time.unscaledDeltaTime;
            _fpsSum += currentFPS;
            _frameCount++;

            if (currentFPS > _bestFPS)
                _bestFPS = (int)currentFPS;

            if (currentFPS < _lowestFPS && _isGameLoaded)
                _lowestFPS = (int)currentFPS;
        }
    }
}