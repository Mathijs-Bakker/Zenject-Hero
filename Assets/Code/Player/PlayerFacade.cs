using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerFacade : MonoBehaviour
    {
        private PlayerModel _playerModel;
        private PlayerDeathHandler _playerDeathHandler;

        [Inject]
        public void Construct(
            PlayerModel playerModel,
            PlayerDeathHandler playerDeathHandler)
        {
            _playerModel = playerModel;
            _playerDeathHandler = playerDeathHandler;
        }

        private void Update()
        {
            if (_playerModel.IsDead) Debug.Log("Player Got Killed");
        }

        public Vector2 Position => _playerModel.Position;
        public bool IsFacingLeft => _playerModel.IsFacingLeft;
        public bool HasMoved => _playerModel.HasMoved;

        public bool HasWon { get; set; }

        public void Die()
        {
            _playerDeathHandler.Die();
        }
    }
}