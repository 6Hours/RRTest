using RRTest.Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RRTest.UI.ItemsVisualizators
{
    public class CardItemVisualizator : BaseItemVisualizator<CardItem>
    {
        [SerializeField] private Image icon;
        [SerializeField] private Text titleText;
        [SerializeField] private Text descriptionText;
        [SerializeField] private Text attackValueText;
        [SerializeField] private Text hpValueText;
        [SerializeField] private Text mpValueText;

        public override void UpdateItem(CardItem _item)
        {
            base.UpdateItem(_item);
            //icon.sprite = 
        }
    }
}
