using System;
using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerMovementHandler : IFixedTickable
    {
        private readonly PlayerAnimatorHandler _animatorHandler;
        private readonly PlayerInputState _inputState;
        private readonly PlayerModel _playerModel;
        private readonly Settings _settings;

        public PlayerMovementHandler(
            Settings settings,
            PlayerModel playerModel,
            PlayerInputState playerInputState,
            PlayerAnimatorHandler playerAnimatorHandler)
        {
            _settings = settings;
            _playerModel = playerModel;
            _inputState = playerInputState;
            _animatorHandler = playerAnimatorHandler;
        }

        public void FixedTick()
        {
            if (_playerModel.IsDead) return;

            if (_inputState.IsMovingUp)
            {
                _animatorHandler.SetAnimator(PlayerAnimatorHandler.AnimationState.Fly);
                _playerModel.AddForce(
                    Vector2.up * _settings.MoveSpeed);
            }

            if (_inputState.IsMovingDown)
                _playerModel.AddForce(
                    Vector2.down * _settings.MoveSpeed);

            if (_inputState.IsMovingLeft)
            {
                _animatorHandler.SetAnimator(PlayerAnimatorHandler.AnimationState.Run);
                _playerModel.FaceLeft(true);
                _playerModel.AddForce(
                    Vector2.left * _settings.MoveSpeed);
            }

            if (_inputState.IsMovingRight)
            {
                _animatorHandler.SetAnimator(PlayerAnimatorHandler.AnimationState.Run);
                _playerModel.FaceLeft(false);
                _playerModel.AddForce(
                    Vector2.right * _settings.MoveSpeed);
            }

            if (_inputState.IsFiring ||
                _inputState.IsMovingDown ||
                _inputState.IsMovingLeft ||
                _inputState.IsMovingRight ||
                _inputState.IsMovingUp)
            {
                _playerModel.HasMoved = true;
            }
        }

        [Serializable]
        public class Settings
        {
            public float MoveSpeed;
        }
    }
}