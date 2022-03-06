using RRTest.UI.ItemsVisualizators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RRTest.Controllers.Decks
{
    [System.Serializable]
    public class PlayerDeck : BaseDeck
    {
        bool isRandomProcess = false;
        protected override void MoveCards()
        {
            var index = 0;
            cards.ForEach(card =>
            {
                var cardTransform = card.GetComponent<RectTransform>();
                cardTransform.DOAnchorPos(GetCardPositionFromIndex(index), 1f);
                cardTransform.DORotate(GetCardRotationAngleFromIndex(index), 1, RotateMode.Fast);
                index++;
            });
        }
        private Vector2 GetCardPositionFromIndex(int index)
        {
            var cardRect = cards[index].GetComponent<RectTransform>();
            var space = RectTransform.sizeDelta.x * 0.8f / cards.Count;
            space = space > cardRect.sizeDelta.x? cardRect.sizeDelta.x : space;

            return RectTransform.anchoredPosition + new Vector2(
                - space * cards.Count / 2 + space * index,
                - Mathf.Abs(Mathf.Sin(-0.5f + 1f / cards.Count * index) * RectTransform.sizeDelta.y * 0.4f));
        }
        private Vector3 GetCardRotationAngleFromIndex(int index)
        {
            var angleSpace = 90f / cards.Count;
            return Vector3.forward * (angleSpace * (cards.Count / 2) - angleSpace * index);
        }
        public void RandomEffectExecute()
        {
            if (isRandomProcess) return;
            RaycastTarget(true);
            StartCoroutine(ChangeValues());
        }
        IEnumerator ChangeValues()
        {
            int lastCount;
            for(var i = 0; i < cards.Count; i+= 1 + cards.Count - lastCount)
            {
                lastCount = cards.Count;
                switch (Random.Range(0,3))
                {
                    case 0:
                        cards[i].Item.Attack = Random.Range(-2, 9);
                        break;
                    case 1:
                        cards[i].Item.MP = Random.Range(-2, 9);
                        break;
                    default:
                        cards[i].Item.HP = Random.Range(-2, 9);
                        break;
                }
                yield return new WaitForSeconds(1.2f);
            }
            isRandomProcess = false;
            RaycastTarget(false);
        }
    }
}

