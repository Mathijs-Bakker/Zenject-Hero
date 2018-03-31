using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerActionHandler : ITickable
    {
        private readonly Player _player;
        private readonly Dynamite.Pool _dynamitePool;
        private readonly PlayerInputState _inputState;
        
        public PlayerActionHandler(
            Player player,
            Dynamite.Pool dynamitePool,
            PlayerInputState playerInputState)
        {
            _player = player;
            _dynamitePool = dynamitePool;
            _inputState = playerInputState;
        }
        
        public void Tick()
        {
            if (_player.IsDead) return;

            // Todo: Input.GetKeyDown should be handled in an InputManager
            if (Input.GetKeyDown(KeyCode.DownArrow) && _player.IsGrounded)
            {
                PlaceDynamite();                
            }

            if (_inputState.IsFiring)
            {
                // Todo: Fire Laser Beam
                Debug.Log("PlayerActionHandler: Fire Laser Beam");
            }
        }

        private void PlaceDynamite()
        {
            var dynamite = _dynamitePool.Spawn();
            dynamite.transform.position = _player.Position;
        }
    }
}