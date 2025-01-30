using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Codebase.UI.Popup
{
    public class Open : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _openBtn;
        [SerializeField] private GameObject _popup;
        [SerializeField] private Image _anticlicker;
        private const float DURATION = 0.15f;

        private void Awake()
        {
            _openBtn.gameObject.SetActive(true);
            _popup.SetActive(false);
            _popup.transform.localScale = Vector3.zero;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _popup.SetActive(true);
            DOTween.Sequence()
                .Append(_anticlicker.DOFade(0, 0f))
                .Append(_popup.transform.DOScale(Vector3.one, DURATION))
                .Append(_anticlicker.DOFade(0.3f, DURATION))
                .SetEase(Ease.InQuad)
                .SetLoops(1, LoopType.Yoyo);
        }
    }
}