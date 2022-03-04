using RRTest.Controllers.Decks;
using System.Collections;
using System.Collections.Generic;
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
            cardItemVisualizator = GetComponent<CardItemVisualizator>();
            OnStartDrag += StartDrag;
            OnFinishDrag += EndDrag;
        }

        private void EndDrag(PointerEventData data)
        {
            if(data.pointerEnter.TryGetComponent<BaseDeck>(out var deck))
            {
                deck.InsertCard(cardItemVisualizator);
            }
        }
        private void StartDrag(PointerEventData data)
        {

        }
    }
}
