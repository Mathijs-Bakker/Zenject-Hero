namespace Player.Code
{
    public class PlayerSpawner
    {
        private readonly PlayerAnimationStates _playerAnimationStates;
        private readonly PlayerModel _playerModel;
        private readonly PlayerPhysics _playerPhysics;

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