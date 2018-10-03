using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerActionHandler : ITickable
    {
        private readonly PlayerModel _playerModel;
        private readonly Dynamite.Code.Dynamite.Pool _dynamitePool;
        private readonly DynamitesCounter _dynamitesCounter;
        private readonly DynamitesActive _dynamitesActive;
        private readonly PlayerInputState _inputState;
        private readonly Laser.Code.Laser _laser;

        public PlayerActionHandler(
            PlayerModel playerModel,
            PlayerInputState playerInputState,
            Dynamite.Code.Dynamite.Pool dynamitePool,
            DynamitesCounter dynamitesCounter,
            DynamitesActive dynamitesActive,
            Laser.Code.Laser laser)
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