using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerGroundedHandler : ITickable
    {
        private readonly PlayerInputState _inputState;
        private readonly Player _player;

        public PlayerGroundedHandler(
            Player player,
            PlayerInputState playerInputState)
        {
            _player = player;
            _inputState = playerInputState;
        }

        public void Tick()
        {
            if (_inputState.IsMovingUp) _player.IsGrounded = false;
        }

        public void PlayerHitFloor(Collision2D other)
        {
            if (other.collider.CompareTag("Floor")) _player.IsGrounded = true;
        }
    }
}