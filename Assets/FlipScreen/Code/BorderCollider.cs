using FlipScreen.Code.Signals;
using Player.Code;
using UnityEngine;
using Zenject;

namespace FlipScreen.Code
{
    public class BorderCollider : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;
        [SerializeField] private ScreenBorder _borderPosition;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerFacade>())
                _signalBus.Fire(new PlayerMovedOutOfScreenSignal(_borderPosition));
        }
    }
}