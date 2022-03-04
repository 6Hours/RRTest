using RRTest.UI.ItemsVisualizators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RRTest.Controllers.Decks
{
    [Serializable]
    public class PlayerDeck : BaseDeck
    {
        protected override void MoveCards()
        {
            var index = 0;
            cards.ForEach(card =>
            {
                var cardTransform = card.GetComponent<RectTransform>();
                cardTransform.DOAnchorPos(GetCardPositionFromIndex(index), 1f);
                cardTransform.DORotate(new Vector3(0f, 0f, -45f + 90f / cards.Count * index), 1, RotateMode.Fast);
                index++;
            });
        }

        private Vector2 GetCardPositionFromIndex(int index)
        {
            return new Vector2(
                -cardContainerTransform.sizeDelta.x * 0.4f + cardContainerTransform.sizeDelta.x * 0.8f / cards.Count * index,
                cardContainerTransform.sizeDelta.y * 0.4f / cards.Count * index);
        }
    }
}

