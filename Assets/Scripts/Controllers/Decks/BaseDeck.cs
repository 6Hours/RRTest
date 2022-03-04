using RRTest.UI;
using RRTest.UI.ItemsVisualizators;
using RRTest.UI.ItemsVisualizators.Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RRTest.Controllers.Decks
{
    public abstract class BaseDeck : MonoBehaviour
    {
        [SerializeField] protected RectTransform cardContainerTransform;
        protected List<CardItemVisualizator> cards;

        public void InsertCard(CardItemVisualizator cardItemVisualizator)
        {
            cards.Add(cardItemVisualizator);
            cardItemVisualizator.GetComponent<RectTransform>().parent = cardContainerTransform;
            cardItemVisualizator.Item.OnChangeItem += () => CheckCard(cardItemVisualizator);
            cardItemVisualizator.GetComponent<CardDragElement>().OnStartDrag += (data) => RemoveCard(cardItemVisualizator);
            cardItemVisualizator.GetComponent<CardDragElement>().SetDeck(this);
            MoveCards();
        }
        public void RemoveCard(CardItemVisualizator cardItemVisualizator)
        {
            cards.Remove(cardItemVisualizator);
            cardItemVisualizator.GetComponent<RectTransform>().parent = cardContainerTransform.parent;
            cardItemVisualizator.Item.OnChangeItem -= () => CheckCard(cardItemVisualizator);
            cardItemVisualizator.GetComponent<DragElement>().OnStartDrag -= (data) => RemoveCard(cardItemVisualizator);
            MoveCards();
        }
        private void CheckCard(CardItemVisualizator cardItemVisualizator)
        {
            if (cardItemVisualizator.Item.HP > 0) return;

            RemoveCard(cardItemVisualizator);
            Destroy(cardItemVisualizator.gameObject, 0.5f);
        }
        protected abstract void MoveCards();
        public virtual void OnDrop(PointerEventData eventData)
        {
            InsertCard(eventData.pointerDrag.GetComponent<CardItemVisualizator>());
        }
        private void RaycastTarget(bool active) => GetComponent<Image>().raycastTarget = active;
    }
}
