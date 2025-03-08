using DG.Tweening;
using UnityEngine;

namespace Codebase.UI.TextAnimation
{
    public class WaveAnimation : MonoBehaviour
    {
        public Sequence Sequence { get; private set; }
        [SerializeField] private float _moveDistance = 250f;
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _waveAmplitude = 10f;
        [SerializeField] private float _waveFrequency = 5f;

        private RectTransform _textTransform;
        private Vector3 _startPosition;

        private void Awake()
        {
            _textTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            Sequence = DOTween.Sequence();

            _startPosition = _textTransform.anchoredPosition + new Vector2(Random.Range(-100f, 100f), 0f);
            Sequence.Append(
                DOTween.To(() => 0f, x =>
                    {
                        Vector2 position = _startPosition + Vector3.up * (x * _moveDistance);
                        position.x += Mathf.Sin(x * _waveFrequency) * _waveAmplitude;
                        _textTransform.anchoredPosition = position;
                    }, 1f, _duration)
                    .SetEase(Ease.Linear)
                    .OnComplete(() => _textTransform.anchoredPosition = new Vector2(0, 0))
            );
        }
    }
}