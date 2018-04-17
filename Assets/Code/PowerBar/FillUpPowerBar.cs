using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class FillUpPowerBar : ITickable
    {
	    private readonly Slider _slider;
	    private readonly AudioSource _fillUpSound;
	    
	    private FillUpPowerBar(
		    Slider slider,
		    AudioSource fillUpSound)
	    {
		    _slider = slider;
		    _fillUpSound = fillUpSound;
	    }

	    public bool HasCompleted { get; set; }

	    public void Tick()
	    {
		    if (!HasCompleted)
		    {
			    Fill();
		    }
	    }

	    private void Fill()
	    {
		    const float fillSpeed = 0.3f;
		    _slider.value += Time.deltaTime * fillSpeed;

		    // Todo: Audio stuff here

		    if (_slider.value >= 1)
		    {
			    HasCompleted = true;
		    }
	    }
    }
}