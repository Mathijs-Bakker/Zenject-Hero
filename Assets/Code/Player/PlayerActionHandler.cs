using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerActionHandler : ITickable
    {
        private readonly Player _player;
        private readonly PlayerInputState _inputState;
        
        public PlayerActionHandler(
            Player player,
            PlayerInputState playerInputState)
        {
            _player = player;
            _inputState = playerInputState;
        }
        
        public void Tick()
        {
            if (_player.IsDead) return;

            if (_inputState.IsMovingDown && _player.IsGrounded)
            {
                // Place Dynamite
                Debug.Log("Dynamite placed");
            }
        }
    }
}