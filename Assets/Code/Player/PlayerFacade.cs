using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerFacade : MonoBehaviour
    {
        private PlayerModel _playerModel;
        private PlayerSpawner _playerSpawner;
        private PlayerDeathHandler _playerDeathHandler;
        private PlayerPhysics _playerPhysics;

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
            if (HasMoved)
            {
                _playerPhysics.GravityOn();
            }
            
            if (_playerModel.IsDead) Debug.Log("Player Got Killed");
        }

        public Vector2 Position => _playerModel.Position;
        public bool IsFacingLeft => _playerModel.IsFacingLeft;
        public bool HasMoved => _playerModel.HasMoved;
        public bool HasWon { get; set; }

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