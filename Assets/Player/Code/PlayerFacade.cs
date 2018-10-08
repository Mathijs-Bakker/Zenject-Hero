using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerFacade : MonoBehaviour
    {
        private PlayerDeathHandler _playerDeathHandler;
        private PlayerModel _playerModel;
        private PlayerPhysics _playerPhysics;
        private PlayerSpawner _playerSpawner;

        public Vector2 Position => _playerModel.Position;
        public bool IsFacingLeft => _playerModel.IsFacingLeft;
        public bool HasMoved => _playerModel.IsMoving;
        public bool HasWon { get; set; }

        [Inject]
        public void Construct(
            PlayerModel playerModel,
            PlayerSpawner playerSpawner,
            PlayerDeathHandler playerDeathHandler,
            PlayerPhysics playerPhysics)
        {
            _playerModel = playerModel;
            _playerSpawner = playerSpawner;
            _playerDeathHandler = playerDeathHandler;
            _playerPhysics = playerPhysics;
        }

        private void Update()
        {
            if (HasMoved) _playerPhysics.GravityOn();
        }

        public void Spawn()
        {
            _playerSpawner.Spawn();
        }

        public void Die()
        {
            _playerDeathHandler.Die();
        }
    }
}