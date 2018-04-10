using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public class PowerManager : MonoBehaviour
	{
		[SerializeField] private Slider _powerBar;
		
		public bool HasGameStarted { get; set; }

		private void Update()
		{
			if (!HasGameStarted)
			{
				FillUpPowerBar();
			}

			if (HasGameStarted)
			{
				_powerBar.value -= 1.1f * Time.deltaTime;
			}
		}

		private void FillUpPowerBar()
		{
			_powerBar.maxValue = 100;
			const float fillSpeed = 30f;

			_powerBar.value += fillSpeed * Time.deltaTime;

			if (_powerBar.value >= 100)
			{
				HasGameStarted = true;
			}
		}

		// Fill Bar from 0 to 100% at beginning of a new level.
		// When bar is full the game is ready to play.
		// When player starts moving or does any input action
		// the power bar start to gonna deplete.
		// If power is depleted the hero dies.
		
		// define Power Units
		// define Maximum Power per level

	}
}
