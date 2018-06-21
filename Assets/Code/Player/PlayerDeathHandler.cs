namespace Code
{
    public class PlayerDeathHandler
    {
        private readonly PlayerModel _playerModel;
        private readonly LivesCounter _livesCounter;
        
        public PlayerDeathHandler(
            PlayerModel playerModel,
            LivesCounter livesCounter)
        {
            _playerModel = playerModel;
            _livesCounter = livesCounter;
        }

        public void Die()
        {
            _playerModel.IsDead = true;
            _livesCounter.SubtractLive();
        }
    }
}