using UnityEngine;
using Zenject;

namespace Code
{
    public interface IPlayer
    {
        Vector2 Position { get; }
    }
    
    
    public class PlayerFacade : MonoBehaviour, IPlayer
    {
        private Player _player;
        private PlayerGroundedHandler _playerGroundedHandler;

        [Inject]
        public void Construct(
            Player player,
            PlayerGroundedHandler playerGroundedHandler)
        {
            _player = player;
            _playerGroundedHandler = playerGroundedHandler;
        }

        public Vector2 Position { get; }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Floor"))
            {
                _playerGroundedHandler.PlayerHitFloor(other);
            }

            if (other.collider.CompareTag("Miner"))
            {
                Debug.Log("Win!");
            }
        }
    }
}        