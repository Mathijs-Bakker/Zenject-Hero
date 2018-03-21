using UnityEngine;
using Zenject;

namespace Code
{
    public class GameManager : MonoBehaviour
    {
        private GameStateFactory _gameStateFactory;
        private GameStateEntity _gameStateEntity = null;

        private GameState _currentGameState;
        
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

            _currentGameState = gameState;
            
            Debug.Log("GameManager: GameState: " + gameState);

            _gameStateEntity = _gameStateFactory.CreateState(gameState);
            _gameStateEntity.Start();
        }
    }
}
