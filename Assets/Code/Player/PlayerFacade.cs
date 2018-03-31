using UnityEngine;
using Zenject;

namespace Code
{
    public interface IPlayer
    {
        bool IsDead { get; }
        Vector2 Position { get; }
    }
    
    
    public class PlayerFacade : MonoBehaviour, IPlayer
    {
        private Player _player;
        private PlayerGroundedHandler _playerGroundedHandler;
        private PlayerDeathHandler _playerDeathHandler;
        
        [Inject]
        public void Construct(
            Player player,
            PlayerGroundedHandler playerGroundedHandler,
            PlayerDeathHandler playerDeathHandler)
        {
            _player = player;
            _playerGroundedHandler = playerGroundedHandler;
            _playerDeathHandler = playerDeathHandler;
        }

        public bool IsDead => _player.IsDead;
        public Vector2 Position => _player.Position;
        
        private void Update()
        {
            if (_player.IsDead)
            {
                Debug.Log("Player Got Killed");
            }
        }

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

        public void Die()
        {
            _playerDeathHandler.Die();
        }

    }
}        