using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Codebase.UI.Popup
{
    public class Close : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _popup;


        public void OnPointerClick(PointerEventData eventData)
        {
            DOTween.Sequence()
                .Append(_popup.transform.DOScale(Vector3.zero, .3f))
                .SetEase(Ease.OutBounce)
                .SetLoops(1, LoopType.Yoyo)
                .OnComplete(() => _popup.SetActive(false));
        }
    }
}