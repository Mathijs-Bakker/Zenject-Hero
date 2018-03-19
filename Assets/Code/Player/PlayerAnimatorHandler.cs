namespace Code
{
    public class PlayerAnimatorHandler
    {
        private readonly Player _player;

        public PlayerAnimatorHandler(
            Player player)
        {
            _player = player;
        }
        
        public enum AnimationState
        {
            Idle,
            Fly,
            Run
        }

        public void SetAnimator(AnimationState state)
        {
            ResetAnimationStates();
            switch (state)
            {
                case AnimationState.Idle:
                    _player.Animator.SetBool("IsIdle", true);
                    break;

                case AnimationState.Fly:
                    _player.Animator.SetBool("IsFlying", true);
                    break;

                case AnimationState.Run:
                    _player.Animator.SetBool("IsRunning", true);
                    break;
            }
        }

        private void ResetAnimationStates()
        {
            _player.Animator.SetBool("IsIdle", false);
            _player.Animator.SetBool("IsFlying", false);
            _player.Animator.SetBool("IsRunning", false);
        }
    }
}