using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRTest.Data.Items
{
    public class CardItem : BaseItem
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        private int attack;
        private int hp;
        private int mp;

        public int Attack
        {
            get
            {
                return attack;
            }
            set
            {
                attack = value;
                OnChangeItem?.Invoke();
            }
        }

        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
                OnChangeItem?.Invoke();
            }
        }
        public int MP
        {
            get
            {
                return mp;
            }
            set
            {
                mp = value;
                OnChangeItem?.Invoke();
            }
        }
    }
}
