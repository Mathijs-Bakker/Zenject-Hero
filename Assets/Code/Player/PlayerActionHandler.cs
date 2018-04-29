using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerActionHandler : ITickable
    {
        private readonly Dynamite.Pool _dynamitePool;
        private readonly PlayerInputState _inputState;
        private readonly Laser _laser;
        private readonly PlayerModel _playerModel;

        public PlayerActionHandler(
            PlayerModel playerModel,
            PlayerInputState playerInputState,
            Dynamite.Pool dynamitePool,
            Laser laser)
        {
            _playerModel = playerModel;
            _inputState = playerInputState;
            _dynamitePool = dynamitePool;
            _laser = laser;
        }

        public void Tick()
        {
            if (_playerModel.IsDead) return;

            // Todo: Input.GetKeyDown should be handled by an InputManager
            if (Input.GetKeyDown(KeyCode.DownArrow) && _playerModel.IsGrounded) PlaceDynamite();

            if (_inputState.IsFiring)
                _laser.IsFiring = true;
            else
                _laser.IsFiring = false;
        }

        private void PlaceDynamite()
        {
            var dynamite = _dynamitePool.Spawn();
            dynamite.transform.position = _playerModel.Position;
        }
    }
}