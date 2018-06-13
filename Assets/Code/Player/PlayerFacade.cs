using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerFacade : MonoBehaviour
    {
        private PlayerModel _playerModel;
        private PlayerDeathHandler _playerDeathHandler;
        private PlayerGroundedHandler _playerGroundedHandler;

        [Inject]
        public void Construct(
            PlayerModel playerModel,
            PlayerGroundedHandler playerGroundedHandler,
            PlayerDeathHandler playerDeathHandler)
        {
            _playerModel = playerModel;
            _playerGroundedHandler = playerGroundedHandler;
            _playerDeathHandler = playerDeathHandler;
        }

        private void Update()
        {
            if (_playerModel.IsDead) Debug.Log("Player Got Killed");
        }

        public Vector2 Position => _playerModel.Position;
        public bool IsFacingLeft => _playerModel.IsFacingLeft;
        public bool HasMoved => _playerModel.HasMoved;

        public bool HasWon { get; set; }

        public void Die()
        {
            _playerDeathHandler.Die();
        }
        
        
        // Todo: Remove OnColisionEnter2D from facade.

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Floor")) _playerGroundedHandler.PlayerHitFloor(other);

            if (other.collider.CompareTag("Miner"))
            {
                HasWon = true;
                Debug.Log("Win!");
            }
        }

    }
}