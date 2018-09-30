using UnityEngine;
using Zenject;

namespace Code.AnimationEvents
{
    public class PlayerReadyEvent : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        
        public void PlayerReady()
        {
            _signalBus.Fire(new PlayerReadySignal());
        }
    }
}