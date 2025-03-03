using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Codebase.Infrastructure.Services.Input
{
    public class CommonClickHandler : MonoBehaviour, IPointerClickHandler, IInputHandler
    {
        public event Action Clicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}