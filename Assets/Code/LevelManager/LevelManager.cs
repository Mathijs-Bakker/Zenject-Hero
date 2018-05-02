using Zenject;

namespace Code
{
	public class LevelManager : IInitializable, ITickable
	{
		// Prepare Player and powerbar
		// When ready:

		private readonly PowerBarFacade _powerBar;
		private readonly PlayerFacade _player;

		private readonly EnemyFacade.Factory _enemyFactory;
		
		public LevelManager(
			EnemyFacade.Factory enemyFactory,
			
			PowerBarFacade powerBarFacade, 
			PlayerFacade playerFacade)
		{
			_enemyFactory = enemyFactory;
			
			_powerBar = powerBarFacade;
			_player = playerFacade;
		}

		public void Initialize()
		{
			var enemy = _enemyFactory.Create();
		}
		
		public void Tick()
		{
			if (_player.HasMoved)
			{
				_powerBar.StartCountDown();
			}
		}

	}
}
