using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace VenCore.UI.Common.Indicators
{
    [System.Serializable]
    public class TextIntIndicator : BaseIndicator<int>
    {
        public override void UpdateValue(int value)
        {
            DOTween.To(() => currentValue, (x) => SetText(x), value, 1).OnComplete(() =>
            {
                currentValue = value;
            });
        }
    }
}
