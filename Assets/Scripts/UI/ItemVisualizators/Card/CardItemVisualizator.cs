using RRTest.Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VenCore.UI.Common.Indicators;

namespace RRTest.UI.ItemsVisualizators
{
    public class CardItemVisualizator : BaseItemVisualizator<CardItem>
    {
        [SerializeField] private Image icon;
        [SerializeField] private Text titleText;
        [SerializeField] private Text descriptionText;
        [SerializeField] private TextIntIndicator attackIndicator;
        [SerializeField] private TextIntIndicator hpIndicator;
        [SerializeField] private TextIntIndicator mpIndicator;

        public override void UpdateItem(CardItem _item)
        {
            base.UpdateItem(_item);
            titleText.text = Item.Title;
            descriptionText.text = Item.Description;
            icon.sprite = Item.Icon;
            attackIndicator.UpdateValue(Item.Attack);
            hpIndicator.UpdateValue(Item.HP);
            mpIndicator.UpdateValue(Item.MP);
        }
    }
}
