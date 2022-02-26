using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VenCore.UI.Common
{
    [Serializable]
    public class TriggerElement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public Action<PointerEventData> OnStartDrag;
        public Action<PointerEventData> OnResumeDrag;
        public Action<PointerEventData> OnFinishDrag;

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnStartDrag?.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnResumeDrag?.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnFinishDrag?.Invoke(eventData);
        }
    }
}
