using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Codebase.UI.Popup
{
    public class Close : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _window;
        [SerializeField] private Image _anticlicker;
        private const float DURATION = 0.15f;

        public void OnPointerClick(PointerEventData eventData)
        {
            DOTween.Sequence()
                .Append(_anticlicker.DOFade(0, DURATION))
                .Append(_window.transform.DOScale(Vector3.zero, DURATION))
                .SetEase(Ease.OutQuad)
                .SetLoops(1, LoopType.Yoyo)
                .OnComplete(() =>
                {
                    _window.SetActive(false);
                    _anticlicker.transform.gameObject.SetActive(false);
                });
        }
    }
}