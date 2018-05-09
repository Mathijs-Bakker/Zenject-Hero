using UnityEngine;
using Zenject;

namespace Code.FlipScreen
{
    public class BorderCollider : MonoBehaviour
    {
        [SerializeField] private ScreenBorder _borderPosition;
        private PlayerMovedOutOfScreenSignal _onPlayerMovedMovedOutOfScreen;

        [Inject]
        private void Construct(PlayerMovedOutOfScreenSignal onPlayerMovedOutOfScreen)
        {
            _onPlayerMovedMovedOutOfScreen = onPlayerMovedOutOfScreen;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerFacade>()) 
                _onPlayerMovedMovedOutOfScreen.Fire(_borderPosition);
        }
    }
}