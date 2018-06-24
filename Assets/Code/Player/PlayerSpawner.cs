namespace Code
{
    public class PlayerSpawner
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerPhysics _playerPhysics;

        public PlayerSpawner(
            PlayerModel playerModel,
            PlayerPhysics playerPhysics)
        {
            _playerModel = playerModel;
            _playerPhysics = playerPhysics;
        }
        public void Spawn()
        {
            _playerPhysics.GravityOff();
            _playerModel.IsSpawning = true;
            _playerModel.Animator.SetBool("IsSpawning", true);
        }
    }
}