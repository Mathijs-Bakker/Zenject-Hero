using System.ComponentModel;
using UnityEngine.SceneManagement;

namespace Code
{
    internal enum GameState
    {
        Menu,
        Play
    }

    public class GameStateFactory
    {
        private readonly PlayState.Factory _gamePlayFactory;
        private readonly MenuState.Factory _menuFactory;

        public GameStateFactory(
            MenuState.Factory menuFactory,
            PlayState.Factory gamePlayFactory)
        {
            _menuFactory = menuFactory;
            _gamePlayFactory = gamePlayFactory;
        }

        internal GameStateEntity CreateState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Menu:
                    return _menuFactory.Create();

                case GameState.Play:
                    SceneManager.LoadSceneAsync(1);
                    return _gamePlayFactory.Create();

                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}