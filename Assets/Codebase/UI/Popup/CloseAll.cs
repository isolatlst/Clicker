using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Codebase.UI.Popup
{
    public class CloseAll : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private List<GameObject> _popups;
        [SerializeField] private Image _anticlicker;
        private const float DURATION = 0.15f;

        public void OnPointerClick(PointerEventData eventData)
        {
            foreach (var popup in _popups)
            {
                popup.transform.DOScale(Vector3.zero, DURATION);
            }

            DOTween.Sequence()
                .Append(_anticlicker.DOFade(0, DURATION))
                .SetEase(Ease.OutQuad)
                .SetLoops(1, LoopType.Yoyo)
                .OnComplete(() => { _anticlicker.transform.gameObject.SetActive(false); });
        }
    }
}