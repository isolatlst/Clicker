using Codebase.FX;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using Codebase.Infrastructure.Signals.Settings;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Codebase.UI.Popup
{
    public class Toggle : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private FxTypes _type;
        [SerializeField] private RectTransform _on;
        [SerializeField] private RectTransform _off;
        [SerializeField] private float _duration = 0.2f;
        private bool _isOn;
        private Sequence _sequence;

        private void Awake()
        {
            SignalBus.Subscribe<LoadFxSettingsSignal>(Synchronize);
        }

        private void Synchronize(LoadFxSettingsSignal signal)
        {
            _isOn = signal.FxStatuses[_type];
            PlayAnim();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _isOn = !_isOn;
            SignalBus.Fire(new SwapFxStatusSignal(_type, _isOn));
            PlayAnim();
        }

        private void PlayAnim()
        {
            _sequence = DOTween.Sequence();
            if (_isOn)
            {
                _sequence
                    .Append(_off.GetComponent<Image>().DOFade(0f, 2 * _duration))
                    .Join(_off.DOPivotX(1f, _duration))
                    .Join(_off.DOAnchorMin(new Vector2(1f, 0f), _duration))
                    .Join(_off.DOAnchorMax(new Vector2(1f, 1f), _duration));
                _sequence
                    .Join(_on.GetComponent<Image>().DOFade(1f, 2 * _duration))
                    .Join(_on.DOPivotX(1, _duration))
                    .Join(_on.DOAnchorMin(new Vector2(1f, 0f), _duration))
                    .Join(_on.DOAnchorMax(new Vector2(1f, 1f), _duration));
            }
            else
            {
                _sequence
                    .Append(_off.GetComponent<Image>().DOFade(1f, 2 * _duration))
                    .Join(_off.DOPivotX(0, _duration))
                    .Join(_off.DOAnchorMin(new Vector2(0f, 0f), _duration))
                    .Join(_off.DOAnchorMax(new Vector2(0f, 1f), _duration));
                _sequence
                    .Join(_on.GetComponent<Image>().DOFade(0f, 2 * _duration))
                    .Join(_on.DOPivotX(0f, _duration))
                    .Join(_on.DOAnchorMin(new Vector2(0f, 0f), _duration))
                    .Join(_on.DOAnchorMax(new Vector2(0f, 1f), _duration));
            }
        }
    }
}