using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerFacade : MonoBehaviour
    {
        private Player _player;
        private PlayerDeathHandler _playerDeathHandler;
        private PlayerGroundedHandler _playerGroundedHandler;

        public Vector2 Position => _player.Position;
        public bool IsFacingLeft => _player.IsFacingLeft;

        public bool HasWon { get; set; }

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

        private void Update()
        {
            if (_player.IsDead) Debug.Log("Player Got Killed");
        }

        // Todo: Remove OnColisionEnter2D from facade.
        // Needs to be in another class.

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Floor")) _playerGroundedHandler.PlayerHitFloor(other);

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