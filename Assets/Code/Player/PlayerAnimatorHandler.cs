namespace Code
{
    public class PlayerAnimatorHandler
    {
        public enum AnimationState
        {
            Idle,
            Fly,
            Run
        }

        private readonly PlayerModel _playerModel;

        public PlayerAnimatorHandler(
            PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void SetAnimator(AnimationState state)
        {
            ResetAnimationStates();
            switch (state)
            {
                case AnimationState.Idle:
                    _playerModel.Animator.SetBool("IsIdle", true);
                    break;

                case AnimationState.Fly:
                    _playerModel.Animator.SetBool("IsFlying", true);
                    break;

                case AnimationState.Run:
                    _playerModel.Animator.SetBool("IsRunning", true);
                    break;
            }
        }

        private void ResetAnimationStates()
        {
            _playerModel.Animator.SetBool("IsIdle", false);
            _playerModel.Animator.SetBool("IsFlying", false);
            _playerModel.Animator.SetBool("IsRunning", false);
        }
    }
}