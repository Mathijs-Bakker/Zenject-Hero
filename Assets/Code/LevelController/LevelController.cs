using Zenject;

namespace Code
{
	public class LevelController : ITickable, IInitializable
	{
		private readonly PlayerFacade _playerFacade;
		private readonly PowerBarFacade _powerBar;
		private readonly LivesCounter _livesCounter;
		private readonly DynamitesCounter _dynamitesCounter;

		public LevelController(
			PlayerFacade playerFacade,
			PowerBarFacade powerBarFacade,
			LivesCounter livesCounter,
			DynamitesCounter dynamitesCounter
			)
		{
			_playerFacade = playerFacade;
			_powerBar = powerBarFacade;
			_livesCounter = livesCounter;
			_dynamitesCounter = dynamitesCounter;
		}
		
		public void Initialize()
		{
			_livesCounter.ResetLivesCounter();
			_dynamitesCounter.ResetDynamiteCounter();
			_playerFacade.Spawn();
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
