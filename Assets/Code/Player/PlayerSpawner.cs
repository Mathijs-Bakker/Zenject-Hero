namespace Code
{
    public class PlayerSpawner
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerPhysics _playerPhysics;
        private readonly PlayerAnimationStates _playerAnimationStates;

        public PlayerSpawner(
            PlayerModel playerModel,
            PlayerPhysics playerPhysics,
            PlayerAnimationStates playerAnimationStates)
        {
            _playerModel = playerModel;
            _playerPhysics = playerPhysics;
            _playerAnimationStates = playerAnimationStates;
        }
        public void Spawn()
        {
            _playerPhysics.GravityOff();
            _playerModel.IsSpawning = true;
            _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Spawn);
        }
    }
}