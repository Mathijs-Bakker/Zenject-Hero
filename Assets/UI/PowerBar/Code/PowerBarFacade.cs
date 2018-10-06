using UnityEngine;
using Zenject;

namespace Code
{
    public class PowerBarFacade : MonoBehaviour
    {
        private PowerBar _powerBar;
        private RestorePowerBar _restorePowerBar;

        [Inject]
        public void Construct(
            PowerBar powerBar,
            RestorePowerBar restorePowerBar)
        {
            _powerBar = powerBar;
            _restorePowerBar = restorePowerBar;
        }

        public void StartCountDown()
        {
            _powerBar.IsGameRunning = true;
        }

        public bool HasPowerBarRestored()
        {
            return _restorePowerBar.HasCompleted;
        }

        // IsPowerbarReady -> Release player controlls
        // IsPowerBarTimerEnded -> GameLevel Over
        // HasPowerBarStarted -> run timer
    }
}