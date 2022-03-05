using RRTest.Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRTest.UI.ItemsVisualizators
{
    public abstract class BaseItemVisualizator<T> : MonoBehaviour
    {
        private T item;

        public virtual void UpdateItem(T _item)
        {
            if(item != null) (item as BaseItem).OnChangeItem -= () => UpdateItem(item);
            item = _item;
            (item as BaseItem).OnChangeItem += () => UpdateItem(item);
        }

        public T Item => item;
    }
}
