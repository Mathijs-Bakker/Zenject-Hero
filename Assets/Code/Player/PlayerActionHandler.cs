using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerActionHandler : ITickable
    {
        private readonly Player _player;
        private readonly PlayerInputState _inputState;
        private readonly Dynamite.Pool _dynamitePool;
        private readonly Laser _laser;

        public PlayerActionHandler(
            Player player,
            PlayerInputState playerInputState,
            Dynamite.Pool dynamitePool,
            Laser laser)
        {
            _player = player;
            _inputState = playerInputState;
            _dynamitePool = dynamitePool;
            _laser = laser;
        }
        
        public void Tick()
        {
            if (_player.IsDead) return;

            // Todo: Input.GetKeyDown should be handled by an InputManager
            if (Input.GetKeyDown(KeyCode.DownArrow) && _player.IsGrounded)
            {
                PlaceDynamite();                
            }

            if (_inputState.IsFiring)
            {
                _laser.IsFiring = true;
            }
            else
            {
                _laser.IsFiring = false;
            }
        }

        private void PlaceDynamite()
        {
            var dynamite = _dynamitePool.Spawn();
            dynamite.transform.position = _player.Position;
        }
    }
}