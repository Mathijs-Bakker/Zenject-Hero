using UnityEngine;
using Zenject;

namespace Code.FlipScreen
{
    public class BorderCollider : MonoBehaviour
    {
        [SerializeField] private ScreenBorder _borderPosition;

        [Inject] private readonly SignalBus _signalBus;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerFacade>()) 
                _signalBus.Fire(new PlayerMovedOutOfScreenSignal(_borderPosition));
        }
    }
}