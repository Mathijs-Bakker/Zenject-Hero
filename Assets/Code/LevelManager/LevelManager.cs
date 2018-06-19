using Zenject;

namespace Code
{
	public class LevelManager : ITickable, IInitializable
	{
		private readonly PlayerFacade _playerFacade;
		private readonly PowerBarFacade _powerBar;
		private readonly DynamiteCounter _dynamiteCounter;

		public LevelManager(
			PlayerFacade playerFacade,
			PowerBarFacade powerBarFacade,
			DynamiteCounter dynamiteCounter
			)
		{
			_playerFacade = playerFacade;
			_powerBar = powerBarFacade;
			_dynamiteCounter = dynamiteCounter;
		}
		
		public void Initialize()
		{
			_dynamiteCounter.ResetDynamiteCounter();
		}

		public void Tick()
		{
			if (_playerFacade.HasMoved)
			{
				_powerBar.StartCountDown();
			}
		}
	}
}
