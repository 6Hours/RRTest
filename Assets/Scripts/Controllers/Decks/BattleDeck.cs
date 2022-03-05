using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRTest.Controllers.Decks
{
    [System.Serializable]
    public class BattleDeck : BaseDeck
    {       
        protected override void MoveCards()
        {
            var index = 0;
            cards.ForEach(card =>
            {
                var cardTransform = card.GetComponent<RectTransform>();
                cardTransform.DOAnchorPos(GetCardPositionFromIndex(index), 1f);
                cardTransform.DORotate(Vector3.zero, 1, RotateMode.Fast);
                index++;
            });
        }

        private Vector2 GetCardPositionFromIndex(int index)
        {
            return RectTransform.anchoredPosition + new Vector2(
                -RectTransform.sizeDelta.x * 0.4f + RectTransform.sizeDelta.x * 0.8f / cards.Count * index,
                0f);
        }
    }
}
