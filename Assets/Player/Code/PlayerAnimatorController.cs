using Zenject;

namespace Player.Code
{
    public class PlayerAnimatorController : ITickable
    {
        private readonly PlayerAnimationStates _playerAnimationStates;
        private readonly PlayerModel _playerModel;

        public PlayerAnimatorController(
            PlayerAnimationStates playerAnimationStates,
            PlayerModel playerModel)
        {
            _playerAnimationStates = playerAnimationStates;
            _playerModel = playerModel;
        }

        public void Tick()
        {
            Spawn();
            Idle();
            Run();
            Fly();
            Die();
        }

        private void Spawn()
        {
            if (_playerModel.IsMoving && _playerModel.IsReady)
                _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.PlayerReady);
        }

        private void Idle()
        {
            if (_playerModel.IsMoving) return;
            _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Idle);
        }

        private void Run()
        {
            if (_playerModel.IsGrounded && _playerModel.IsMoving)
                _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Run);
        }

        private void Fly()
        {
            if (!_playerModel.IsGrounded && _playerModel.IsMoving)
                _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Fly);
        }

        private void Die()
        {
            if (_playerModel.IsDead) _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Die);
        }
    }
}