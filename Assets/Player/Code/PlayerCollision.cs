using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerCollision : MonoBehaviour
    {
        private PlayerGrounded _playerGrounded;
        private PlayerFacade _playerFacade;

        [Inject]
        public void Construct(
            PlayerGrounded playerGrounded,
            PlayerFacade playerFacade)
        {
            _playerGrounded = playerGrounded;
            _playerFacade = playerFacade;
        }

        
        private void OnCollisionEnter2D(Collision2D other)
        {
            _playerGrounded.PlayerHitFloor(other);

            if (other.collider.CompareTag("Miner"))
            {
                _playerFacade.HasWon = true;
                Debug.Log("Win!");
            }
        }
    }
}