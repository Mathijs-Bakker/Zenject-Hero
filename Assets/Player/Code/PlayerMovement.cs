using System;
using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerMovement : IFixedTickable
    {
        private readonly PlayerAnimationStates _animationStates;
        private readonly PlayerInputState _inputState;
        private readonly PlayerModel _playerModel;
        private readonly Settings _settings;

        public PlayerMovement(
            Settings settings,
            PlayerModel playerModel,
            PlayerInputState playerInputState,
            PlayerAnimationStates playerAnimationStates)
        {
            _settings = settings;
            _playerModel = playerModel;
            _inputState = playerInputState;
        }

        public void FixedTick()
        {
            if (_playerModel.IsDead) return;

            if (_inputState.IsMovingUp) _playerModel.AddForce(Vector2.up * _settings.MoveSpeed);

            if (_inputState.IsMovingDown)
                _playerModel.AddForce(Vector2.down * _settings.MoveSpeed);

            if (_inputState.IsMovingLeft)
            {
                _playerModel.FaceLeft(true);
                _playerModel.AddForce(Vector2.left * _settings.MoveSpeed);
            }

            if (_inputState.IsMovingRight)
            {
                _playerModel.FaceLeft(false);
                _playerModel.AddForce(Vector2.right * _settings.MoveSpeed);
            }

            // Todo: Idle state

            if (_inputState.IsFiring ||
                _inputState.IsMovingDown ||
                _inputState.IsMovingLeft ||
                _inputState.IsMovingRight ||
                _inputState.IsMovingUp)
                _playerModel.IsMoving = true;
            else
                _playerModel.IsMoving = false;
        }

        [Serializable]
        public class Settings
        {
            public float MoveSpeed;
        }
    }
}