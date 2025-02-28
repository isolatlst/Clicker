using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Codebase.UI.Popup
{
    public class Open : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _popup;
        [SerializeField] private Image _anticlicker;
        private const float DURATION = 0.15f;
        private int _startOrder;

        private void Awake()
        {
            _startOrder = _anticlicker.GetComponent<Canvas>().sortingOrder;
            _popup.transform.parent.gameObject.SetActive(false);
            _popup.transform.localScale = Vector3.zero;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _popup.transform.parent.gameObject.SetActive(true);
            _anticlicker.transform.gameObject.SetActive(true);
            _popup.GetComponent<Canvas>().sortingOrder = _startOrder + (int)Time.time;

            DOTween.Sequence()
                .Append(_anticlicker.DOFade(0, 0f))
                .Append(_popup.transform.parent.transform.DOScale(Vector3.one, DURATION))
                .Append(_popup.transform.DOScale(Vector3.one, DURATION))
                .Append(_anticlicker.DOFade(0.3f, DURATION))
                .SetEase(Ease.InQuad)
                .SetLoops(1, LoopType.Yoyo);
        }
    }
}