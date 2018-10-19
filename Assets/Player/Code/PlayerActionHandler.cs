using GameSystem.Dynamites;
using UI.Dynamites.Code;
using UnityEngine;
using Weapons.Dynamite.Code;
using Weapons.Laser.Code;
using Zenject;

namespace Player.Code
{
    public class PlayerActionHandler : ITickable
    {
        private readonly DynamiteController.Pool _dynamitePool;
        private readonly DynamitesController _dynamitesController;
        private readonly DynamitesCount _dynamitesCount;
        private readonly PlayerInputState _inputState;
        private readonly Laser _laser;
        private readonly PlayerModel _playerModel;

        public PlayerActionHandler(
            PlayerModel playerModel,
            PlayerInputState playerInputState,
            DynamiteController.Pool dynamitePool,
            DynamitesCount dynamitesCount,
            DynamitesController dynamitesController,
            Laser laser)
        {
            _playerModel = playerModel;
            _inputState = playerInputState;
            _dynamitePool = dynamitePool;
            _dynamitesCount = dynamitesCount;
            _dynamitesController = dynamitesController;
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
            if (_dynamitesCount.DynamitesLeft <= 0) return;
            if(_dynamitesController.HasMaxAmountExceeded) return;
//            if (_dynamitesTracker.IsDynamiteActive) return;

            var dynamite = _dynamitePool.Spawn();
            Debug.Log("dynamite");
            dynamite.transform.position = _playerModel.Position;
            
            
//            _dynamitesTracker.IsDynamiteActive = true;
            _dynamitesCount.SubtractDynamite();
        }
    }
}