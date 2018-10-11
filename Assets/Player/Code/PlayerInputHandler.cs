using UnityEngine;
using Zenject;

namespace Player.Code
{
    public class PlayerInputHandler : ITickable
    {
        private readonly PlayerInputState _inputState;
        private readonly PlayerModel _playerModel;

        public PlayerInputHandler(
            PlayerInputState inputState,
            PlayerModel playerModel)
        {
            _inputState = inputState;
            _playerModel = playerModel;
        }

        public void Tick()
        {
            if (!_playerModel.IsReady) return;

            _inputState.IsMovingLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
            _inputState.IsMovingRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
            _inputState.IsMovingUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            _inputState.IsMovingDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

            _inputState.IsFiring = Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0);
        }
    }
}