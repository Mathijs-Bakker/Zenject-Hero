using UnityEngine;
using Zenject;

namespace Code.FlipScreen
{
    public class BorderCollider : MonoBehaviour
    {
        [SerializeField] private ScreenBorder _borderPosition;
//        private PlayerMovedOutOfScreenSignal _onPlayerMovedMovedOutOfScreen;


        private readonly SignalBus _signalBus;
//        [Inject]
//        private void Construct(PlayerMovedOutOfScreenSignal onPlayerMovedOutOfScreen)
//        {
//            _onPlayerMovedMovedOutOfScreen = onPlayerMovedOutOfScreen;
//        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerFacade>()) 
                Debug.Log("Whoot");
                _signalBus.Fire(new PlayerMovedOutOfScreenSignal(_borderPosition));
        }
    }
}