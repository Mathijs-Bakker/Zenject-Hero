namespace Code
{
    public class PlayerDeathHandler
    {
        private readonly PlayerModel _playerModel;
        private readonly LivesCounter _livesCounter;
        private readonly PlayerAnimationStates _playerAnimationStates;

        public PlayerDeathHandler(
            PlayerModel playerModel,
            LivesCounter livesCounter,
            PlayerAnimationStates playerAnimationStates)
        {
            _playerModel = playerModel;
            _livesCounter = livesCounter;
            _playerAnimationStates = playerAnimationStates;
        }

        public void Die()
        {
            _playerModel.IsDead = true;
            _livesCounter.SubtractLive();
            _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Die);
        }
    }
}