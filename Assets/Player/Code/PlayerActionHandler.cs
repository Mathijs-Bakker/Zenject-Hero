using Code;
using Weapons.Dynamite.Code;
using Weapons.Laser.Code;
using Zenject;

namespace Player.Code
{
    public class PlayerActionHandler : ITickable
    {
        private readonly Weapons.Dynamite.Code.Dynamite.Pool _dynamitePool;
        private readonly DynamitesActive _dynamitesActive;
        private readonly DynamitesCounter _dynamitesCounter;
        private readonly PlayerInputState _inputState;
        private readonly Laser _laser;
        private readonly PlayerModel _playerModel;

        public PlayerActionHandler(
            PlayerModel playerModel,
            PlayerInputState playerInputState,
            Weapons.Dynamite.Code.Dynamite.Pool dynamitePool,
            DynamitesCounter dynamitesCounter,
            DynamitesActive dynamitesActive,
            Laser laser)
        {
            _playerModel = playerModel;
            _inputState = playerInputState;
            _dynamitePool = dynamitePool;
            _dynamitesCounter = dynamitesCounter;
            _dynamitesActive = dynamitesActive;
            _laser = laser;
        }

        public void Tick()
        {
            if (_playerModel.IsDead) return;

            if (_inputState.IsMovingDown && _playerModel.IsGrounded)
                PlaceDynamite();

            _laser.IsFiring = _inputState.IsFiring;
        }

        private void PlaceDynamite()
        {
            if (_dynamitesCounter.DynamitesLeft <= 0) return;
            if (_dynamitesActive.IsDynamiteActive) return;

            var dynamite = _dynamitePool.Spawn();
            dynamite.transform.position = _playerModel.Position;

            _dynamitesActive.IsDynamiteActive = true;
            _dynamitesCounter.SubtractDynamite();
        }
    }
}