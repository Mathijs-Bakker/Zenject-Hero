using UnityEngine;
using Zenject;

namespace Code.FlipScreen
{
    public class BorderCollider : MonoBehaviour
    {
        private PlayerOutOfScreenSignal _onPlayerOutOfScreen;
        [SerializeField] private ScreenBoundary _screenBoundary;

        [Inject]
        void Construct(PlayerOutOfScreenSignal onPlayerOutOfScreen)
        {
            _onPlayerOutOfScreen = onPlayerOutOfScreen;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                _onPlayerOutOfScreen.Fire(_screenBoundary);
            }
        }
    }
}
