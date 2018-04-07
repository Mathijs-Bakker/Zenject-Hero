using UnityEngine;
using Zenject;

namespace Code
{
    public class GameManager : MonoBehaviour
    {
        private GameStateFactory _gameStateFactory;
        private GameStateEntity _gameStateEntity;

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
