using Zenject;

namespace Code
{
	public class LevelManager : ITickable
	{
		private readonly PowerBarFacade _powerBar;
		private readonly PlayerFacade _player;

		public LevelManager(
			PowerBarFacade powerBarFacade, 
			PlayerFacade playerFacade)
		{
			_powerBar = powerBarFacade;
			_player = playerFacade;
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
