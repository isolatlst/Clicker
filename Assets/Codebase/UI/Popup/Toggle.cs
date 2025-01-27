using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Codebase.UI.Popup
{
    public class Toggle : MonoBehaviour, IPointerClickHandler
    {
        public event Action<bool> Toggled;
        [SerializeField] private RectTransform _on;
        [SerializeField] private RectTransform _off;
        [SerializeField] private float _duration = 0.2f;
        private bool _isOn;
        private Sequence _sequence;

        public void Synchronize(bool isOn) // для сейвов
        {
            _isOn = isOn;
            PlayAnim();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _isOn = !_isOn;
            Toggled?.Invoke(_isOn);
            
            PlayAnim();
        }

        private void Awake()
        {
            Synchronize(true);
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
                    .Join(_on.GetComponent<Image>().DOFade(1f, 2*_duration))
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
                    .Join(_on.GetComponent<Image>().DOFade(0f, 2*_duration))
                    .Join(_on.DOPivotX(0f, _duration))
                    .Join(_on.DOAnchorMin(new Vector2(0f, 0f), _duration))
                    .Join(_on.DOAnchorMax(new Vector2(0f, 1f), _duration));
            }
        }
    }
}