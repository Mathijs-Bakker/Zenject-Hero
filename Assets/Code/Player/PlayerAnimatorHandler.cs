using Zenject;

namespace Code
{
    public class PlayerAnimatorHandler : ITickable
    {
        private readonly PlayerAnimationStates _playerAnimationStates;
        private readonly PlayerModel _playerModel;
        private readonly PlayerGroundedHandler _playerGroundedHandler;

        public PlayerAnimatorHandler(
            PlayerAnimationStates playerAnimationStates,
            PlayerModel playerModel,
            PlayerGroundedHandler playerGroundedHandler)
        {
            _playerAnimationStates = playerAnimationStates;
            _playerModel = playerModel;
            _playerGroundedHandler = playerGroundedHandler;
        }

        public void Tick()
        {
            
            SpawnState();
            IdleState();

            
            if (_playerModel.IsRunning)
            {
                _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Run);
            }

            if (_playerModel.IsDead)
            {
                _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Die);
            }
        }

        private void IdleState()
        {
            if (_playerModel.IsMoving) return;
            _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Idle);
        }

        private void SpawnState()
        {
            if (_playerModel.IsMoving && _playerModel.IsReady)
            {
                _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.HasMoved);
            }
        }
    }
}