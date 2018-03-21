using System.ComponentModel;

namespace Code
{
    internal enum GameState
    {
        Menu,
        Play
    }
    
    public class GameStateFactory
    {
        private readonly MenuState.Factory _menuFactory;
        private readonly PlayState.Factory _gamePlayFactory;

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
                    return _gamePlayFactory.Create();
                
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}