using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code
{
    public class PlayerFacade : MonoBehaviour
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

        public Vector2 Position => _player.Position;
        public bool IsFacingLeft => _player.IsFacingLeft;
        
        private void Update()
        {
            if (_player.IsDead)
            {
                // Todo: Game manager death handler.
                Debug.Log("Player Got Killed");
            }
        }

        public bool HasWon { get; set; }
        
        // Todo: Remove OnColisionEnter2D from facade.
        // Needs to be in another class.
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Floor"))
            {
                _playerGroundedHandler.PlayerHitFloor(other);
            }

            if (other.collider.CompareTag("Miner"))
            {
                HasWon = true;                
                Debug.Log("Win!");
            }
        }

        public void Die()
        {
            _playerDeathHandler.Die();
        }

    }
}        