using UnityEngine;

namespace Code
{
    public class PlayerAnimatorHandler
    {
        private readonly Animator _animator;

        public enum AnimationState
        {
            Spawn,
            Idle,
            Fly,
            Run,
            Die
        }

        private readonly PlayerModel _playerModel;

        public PlayerAnimatorHandler(Animator animator)
        {
            _animator = animator;
        }

        public void SetAnimator(AnimationState state)
        {
            ResetAnimationStates();
            switch (state)
            {
                case AnimationState.Spawn:
                    _animator.SetBool("IsSpawning", true);
                    break;
                
                case AnimationState.Idle:
                    _animator.SetBool("IsIdle", true);
                    break;

                case AnimationState.Fly:
                    _animator.SetBool("IsFlying", true);
                    break;

                case AnimationState.Run:
                    _animator.SetBool("IsRunning", true);
                    break;
                
                case AnimationState.Die:
                    _animator.SetBool("IsDead", true);
                    break;
            }
        }

        private void ResetAnimationStates()
        {
            _animator.SetBool("IsSpawning", false);
            _animator.SetBool("IsIdle", false);
            _animator.SetBool("IsFlying", false);
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsDead", false);
        }
    }
}