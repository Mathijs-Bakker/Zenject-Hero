using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerGrounded : ITickable
    {
        private readonly PlayerInputState _inputState;
        private readonly PlayerModel _playerModel;

        public PlayerGrounded(
            PlayerModel playerModel,
            PlayerInputState playerInputState)
        {
            _playerModel = playerModel;
            _inputState = playerInputState;
        }

        public void Tick()
        {
            if (_inputState.IsMovingUp) _playerModel.IsGrounded = false;
        }

        public void PlayerHitFloor(Collision2D other)
        {
            if (other.collider.CompareTag("Floor")) _playerModel.IsGrounded = true;
        }
    }
}