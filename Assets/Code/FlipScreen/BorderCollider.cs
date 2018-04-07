using UnityEngine;
using Zenject;

namespace Code.FlipScreen
{
    public class BorderCollider : MonoBehaviour
    {
        private PlayerMovedOutOfScreenSignal _onPlayerMovedMovedOutOfScreen;
        [SerializeField] private ScreenBorder _borderPosition;

        [Inject]
        private void Construct(PlayerMovedOutOfScreenSignal onPlayerMovedOutOfScreen)
        {
            _onPlayerMovedMovedOutOfScreen = onPlayerMovedOutOfScreen;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.GetComponent<PlayerFacade>())
            {
                _onPlayerMovedMovedOutOfScreen.Fire(_borderPosition);
            }
        }
    }
}
