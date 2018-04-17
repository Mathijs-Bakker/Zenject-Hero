using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class PowerBar : ITickable
	{
		private readonly Slider _slider;

		private PlayerFacade _player;

		private FillUpPowerBar _fillUpPowerBar;

		private PowerBar(
			Slider slider,
			PlayerFacade player,
			FillUpPowerBar fillUpPowerBar)
		{
			_slider = slider;
			_player = player;
			_fillUpPowerBar = fillUpPowerBar;
		}

		public void Tick()
		{
			if (!_fillUpPowerBar.HasCompleted) return;

			const float countDownSpeed = 0.01f;
			_slider.value -= Time.deltaTime * countDownSpeed;
		}
		
		
		public void SetValue(float value)
		{
			_slider.value += value;
		}
		
		public bool HasGameStarted { get; set; }
		
		
		
		
		// Fill Bar from 0 to 100% at beginning of a new level.
		// When bar is full the game is ready to play.
		// When player starts moving or does any input action
		// the power bar start to gonna deplete.
		// If power is depleted the hero dies.
		
		// define Power Units
		// define Maximum Power per level

	}
}
