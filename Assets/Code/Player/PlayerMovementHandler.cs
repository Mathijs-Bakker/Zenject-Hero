using System;
using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerMovementHandler : IFixedTickable
    {
        private readonly Settings _settings;
        private readonly Player _player;
        private readonly PlayerInputState _inputState;
        private readonly PlayerAnimatorHandler _animatorHandler;

        public PlayerMovementHandler(
            Settings settings,
            Player player,
            PlayerInputState playerInputState,
            PlayerAnimatorHandler playerAnimatorHandler)
        {
            _settings = settings;
            _player = player;
            _inputState = playerInputState;
            _animatorHandler = playerAnimatorHandler;
        }
        public void FixedTick()
        {
            if (_player.IsDead) return;

            if (_inputState.IsMovingUp)
            {
                _animatorHandler.SetAnimator(PlayerAnimatorHandler.AnimationState.Fly);
                _player.AddForce(
                    Vector2.up * _settings.MoveSpeed);
            }
            
            if (_inputState.IsMovingDown)
            {
                _player.AddForce(
                    Vector2.down * _settings.MoveSpeed);
            }

            if (_inputState.IsMovingLeft)
            {
                _animatorHandler.SetAnimator(PlayerAnimatorHandler.AnimationState.Run);                
                _player.FaceLeft(true);
                _player.AddForce(
                    Vector2.left * _settings.MoveSpeed);
            }
            
            if (_inputState.IsMovingRight)
            {
                _animatorHandler.SetAnimator(PlayerAnimatorHandler.AnimationState.Run);                
                _player.FaceLeft(false);
                _player.AddForce(
                    Vector2.right * _settings.MoveSpeed);
            }
        }
        
        [Serializable]
        public class Settings
        {
            public float MoveSpeed;
        }
    }
}