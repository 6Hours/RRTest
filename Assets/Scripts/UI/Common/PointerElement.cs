using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RRTest.UI
{
    [Serializable]
    public class PointerElement : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Action<PointerEventData> OnDropped;
        public Action<PointerEventData> OnEnter;
        public Action<PointerEventData> OnExit;

        public void OnDrop(PointerEventData eventData)
        {
            OnDropped?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnEnter?.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnExit?.Invoke(eventData);
        }
    }
}
