using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerCollision : MonoBehaviour
    {
        private PlayerGroundedHandler _playerGroundedHandler;
        private PlayerFacade _playerFacade;

        [Inject]
        public void Construct(
            PlayerGroundedHandler playerGroundedHandler,
            PlayerFacade playerFacade)
        {
            _playerGroundedHandler = playerGroundedHandler;
            _playerFacade = playerFacade;
        }

        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Floor")) _playerGroundedHandler.PlayerHitFloor(other);

            if (other.collider.CompareTag("Miner"))
            {
                _playerFacade.HasWon = true;
                Debug.Log("Win!");
            }
        }
    }
}