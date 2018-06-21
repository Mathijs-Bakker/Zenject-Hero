using Zenject;

namespace Code
{
	public class LevelManager : ITickable, IInitializable
	{
		private readonly PlayerFacade _playerFacade;
		private readonly PowerBarFacade _powerBar;
		private readonly DynamitesCounter _dynamitesCounter;

		public LevelManager(
			PlayerFacade playerFacade,
			PowerBarFacade powerBarFacade,
			DynamitesCounter dynamitesCounter
			)
		{
			_playerFacade = playerFacade;
			_powerBar = powerBarFacade;
			_dynamitesCounter = dynamitesCounter;
		}
		
		public void Initialize()
		{
			_dynamitesCounter.ResetDynamiteCounter();
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
