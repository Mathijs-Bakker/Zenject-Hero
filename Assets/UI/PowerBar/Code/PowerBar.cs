using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class PowerBar : ITickable
    {
        private readonly Slider _slider;
        private readonly PlayerFacade _playerFacade;
        private readonly RestorePowerBar _restorePowerBar;

        private PowerBar(
            Slider slider,
            PlayerFacade playerFacade,
            RestorePowerBar restorePowerBar)
        {
            _slider = slider;
            _playerFacade = playerFacade;
            _restorePowerBar = restorePowerBar;
        }

        public bool IsGameRunning { get; set; }

        public void Tick()
        {
            if (!_restorePowerBar.HasCompleted) return;
            if (!IsGameRunning) return;
            
            const float countDownSpeed = 0.01f;
            _slider.value -= Time.deltaTime * countDownSpeed;

            if (_slider.value <= 0) _playerFacade.Die();
        }


        // Fill Bar from 0 to 100% at beginning of a new level.
        // When bar is full the game is ready to play.
        // When player starts moving or does any input action
        // the power bar start to gonna deplete.
        // If power is depleted the hero dies.

        // define Power Units
        // define Maximum Power per level
    }
}