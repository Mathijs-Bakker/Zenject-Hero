namespace Code
{
    public class PlayerDeathHandler
    {
        private readonly PlayerModel _playerModel;

        public PlayerDeathHandler(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Die()
        {
            _playerModel.IsDead = true;
        }
    }
}