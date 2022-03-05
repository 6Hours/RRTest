using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RRTest.UI
{
    public abstract class DragElement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public System.Action<PointerEventData> OnStartDrag;
        public System.Action<PointerEventData> OnFinishDrag;
        public System.Action<Vector2> OnDragEvent;

        private Image image;
        private RectTransform rect;
        private Vector2 offset;
        public void Initialize()
        {
            rect = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        public Image GetImage() { return image; }

        public void OnBeginDrag(PointerEventData eventData)
        {
#if UNITY_EDITOR
            offset = Input.mousePosition;
#else
        offset = Input.GetTouch(0).position;
#endif
            offset -= rect.anchoredPosition;
            OnStartDrag?.Invoke(eventData);
            image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
#if UNITY_EDITOR
            Vector2 currentMousePosition = Input.mousePosition;
#else
            Vector2 currentMousePosition = Input.GetTouch(0).position;
#endif
            Vector2 newPosition = RectTransform.anchoredPosition;
            if (IsValueInsideRange((currentMousePosition - offset).x, Screen.width - RectTransform.sizeDelta.x))
            {
                newPosition.x = (currentMousePosition - offset).x;
            }
            if (IsValueInsideRange((currentMousePosition - offset).y, Screen.height - RectTransform.sizeDelta.y))
            {
                newPosition.y = (currentMousePosition - offset).y;
            }
            RectTransform.anchoredPosition = newPosition;
            OnDragEvent?.Invoke(RectTransform.anchoredPosition);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            image.raycastTarget = true;
            OnFinishDrag?.Invoke(eventData);
        }

        public bool IsValueInsideRange(float value, float rangeSize)
        {
            return (Mathf.Abs(value) < rangeSize * 0.5f);
        }
        
        public void Translate(Vector2 position)
        {
            rect.anchoredPosition = position;
            OnDragEvent?.Invoke(position);
        }

        public RectTransform RectTransform
        {
            get
            {
                return rect;
            }
        }
    }
}