using UnityEngine;
using Zenject;

namespace Code
{
    public class GameManager : MonoBehaviour
    {
        private GameStateEntity _gameStateEntity;
        private GameStateFactory _gameStateFactory;

        [Inject]
        public void Construct(GameStateFactory gameStateFactory)
        {
            _gameStateFactory = gameStateFactory;
        }

        private void Start()
        {
            ChangeState(GameState.Menu);
        }

        internal void ChangeState(GameState gameState)
        {
            if (_gameStateEntity != null)
            {
                _gameStateEntity.Dispose();
                _gameStateEntity = null;
            }

            _gameStateEntity = _gameStateFactory.CreateState(gameState);
            _gameStateEntity.Start();
        }
    }
}