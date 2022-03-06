using RRTest.Controllers.Decks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RRTest.UI.ItemsVisualizators.Card
{
    public class CardDragElement : DragElement
    {
        private BaseDeck previousDeck;
        private CardItemVisualizator cardItemVisualizator;

        public void SetDeck(BaseDeck deck)
        {
            previousDeck = deck;
        }

        private void Start()
        {
            Initialize();
            cardItemVisualizator = GetComponent<CardItemVisualizator>();
            OnStartDrag += StartDrag;
            OnFinishDrag += EndDrag;
        }

        private void EndDrag(PointerEventData data)
        {
            ChangeDeckActive(false);
            if(data.pointerEnter != null && data.pointerEnter.TryGetComponent<BaseDeck>(out var deck))
            {
                deck.InsertCard(cardItemVisualizator);
            }
            else
            {
                previousDeck.InsertCard(cardItemVisualizator);
            }
        }
        private void StartDrag(PointerEventData data)
        {
            ChangeDeckActive(true);
            RectTransform.SetAsLastSibling();
        }

        private void ChangeDeckActive(bool active)
        {
            FindObjectsOfType<BaseDeck>().ToList().ForEach(deck => deck.RaycastTarget(active));
        }
    }
}
