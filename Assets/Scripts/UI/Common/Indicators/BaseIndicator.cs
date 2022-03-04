using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace VenCore.UI.Common.Indicators
{
    public abstract class BaseIndicator<T>
    {
        [SerializeField] protected Text textElement;
        protected T currentValue;
        public abstract void UpdateValue(T value);

        public virtual void SetText(T value)
        {
            textElement.text = value.ToString();
        }
    }
}
