using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class StatBar : MonoBehaviour
    {
        public Image ImageCurrentValue;

        public void SetValue(float current, float max) =>
            ImageCurrentValue.fillAmount = current / max;
    }
}