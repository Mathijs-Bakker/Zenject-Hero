using UnityEngine;

namespace Code
{
    public class PowerBarFacade : MonoBehaviour
    {
        private readonly PowerBar _powerBar;
        private readonly RestorePowerBar _restorePowerBar;
        
        public PowerBarFacade(
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