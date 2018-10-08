using Code;
using UnityEngine;
using Zenject;

namespace Player.Code.AnimationEvents
{
    public class PlayerReadyEvent : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus = null;

        public void PlayerReady()
        {
            _signalBus.Fire(new PlayerReadySignal());
        }
    }
}