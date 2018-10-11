using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.PowerBar.Code
{
    public class RestorePowerBar : ITickable
    {
        private readonly Slider _slider;

        private RestorePowerBar(
            Slider slider)
        {
            _slider = slider;
        }

        public bool HasCompleted { get; set; }

        public void Tick()
        {
            if (!HasCompleted) Charge();
        }

        private void Charge()
        {
            const float fillSpeed = 0.3f;
            _slider.value += Time.deltaTime * fillSpeed;

            if (_slider.value >= 1) HasCompleted = true;
        }
    }
}