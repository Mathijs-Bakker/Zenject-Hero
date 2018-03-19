using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerGroundedHandler : ITickable
    {
        private readonly Player _player;
        private readonly PlayerInputState _inputState;

        public PlayerGroundedHandler(
            Player player,
            PlayerInputState playerInputState)
        {
            _player = player;
            _inputState = playerInputState;
        }
    
        public void PlayerHitFloor(Collision2D other)
        {
            if (other.collider.CompareTag("Floor"))
            {
                _player.IsGrounded = true;
            }
        }

        public void Tick()
        {
            if (_inputState.IsMovingUp)
            {
                _player.IsGrounded = false;
            }
        }
    }
}
