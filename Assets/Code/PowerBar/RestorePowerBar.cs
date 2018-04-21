using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class RestorePowerBar : ITickable
    {
        private readonly AudioSource _restorePowerAS;
        private readonly Slider _slider;

        private RestorePowerBar(
            Slider slider,
            AudioSource restorePowerAS)
        {
            _slider = slider;
            _restorePowerAS = restorePowerAS;
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

            // Todo: Audio: Charging sound (Pitch going higher)

            if (_slider.value >= 1) HasCompleted = true;
        }
    }
}