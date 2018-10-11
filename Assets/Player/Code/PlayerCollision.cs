using UnityEngine;
using Zenject;

namespace Player.Code
{
    public class PlayerCollision : MonoBehaviour
    {
        private PlayerFacade _playerFacade;
        private PlayerGrounded _playerGrounded;

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