namespace Code
{
    public class PlayerDeathHandler
    {
        private readonly Player _player;

        public PlayerDeathHandler(Player player)
        {
            _player = player;
        }

        public void Die()
        {
            _player.IsDead = true;
        }
    }
}