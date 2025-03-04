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
            _popup.transform.localScale = Vector3.zero;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _popup.GetComponent<Canvas>().sortingOrder = _startOrder + (int)Time.time;
            _anticlicker.transform.gameObject.SetActive(true);

            DOTween.Sequence()
                .Append(_anticlicker.DOFade(0.3f, DURATION))
                .Append(_popup.transform.DOScale(Vector3.one, DURATION))
                .SetEase(Ease.InQuad)
                .SetLoops(1, LoopType.Yoyo);
        }
    }
}