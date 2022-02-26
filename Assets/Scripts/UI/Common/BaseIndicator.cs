using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace VenCore.UI.Common
{
    public abstract class BaseIndicator<T>
    {
        [SerializeField] private Text textElement;
        public T currentValue = default;

        public abstract void UpdateValue(T value);

        private void SetText()
        {
            textElement.text = currentValue.ToString();
        }
    }
}
