using GameSystem.Dynamites;
using Player.Code;
using UI.Dynamites.Code;
using UI.Lives.Code;
using UI.PowerBar.Code;
using Weapons.Dynamite.Code;
using Zenject;

namespace Code.LevelController
{
	public class LevelController : ITickable, IInitializable
	{
		private readonly PlayerFacade _playerFacade;
		private readonly PowerBarFacade _powerBar;
		private readonly LivesCounter _livesCounter;
		private readonly DynamitesCount _dynamitesCount;

		public LevelController(
			PlayerFacade playerFacade,
			PowerBarFacade powerBarFacade,
			LivesCounter livesCounter,
			DynamitesCount dynamitesCount
			)
		{
			_playerFacade = playerFacade;
			_powerBar = powerBarFacade;
			_livesCounter = livesCounter;
			_dynamitesCount = dynamitesCount;
		}
		
		public void Initialize()
		{
			_livesCounter.ResetLivesCounter();
			_dynamitesCount.ResetDynamiteCounter();
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
