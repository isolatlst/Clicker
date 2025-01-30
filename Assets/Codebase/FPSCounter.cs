using System;
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
        private int _bestFPS;
        private int _lowestFPS = Int32.MaxValue - 1;
        private float _currentFPS;

        private void Awake()
        {
            StartCoroutine(UpdateFPSView());
        }

        private IEnumerator UpdateFPSView()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(1.0f);
                _FPSText.text = "FPS: " + (int)_currentFPS;
                _bestFPSText.text = $"Best: {_bestFPS}";
                _lowestFPSText.text = $"Low: {_lowestFPS}";
            }
        }

        private void Update()
        {
            UpdateFPS();
        }

        private void UpdateFPS()
        {
            _currentFPS = 1f / Time.deltaTime;

            if (_currentFPS > _bestFPS)
                _bestFPS = (int)_currentFPS;

            if (_lowestFPS > _currentFPS)
                _lowestFPS = (int)_currentFPS;
        }
    }
}