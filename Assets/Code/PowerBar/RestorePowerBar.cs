using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class RestorePowerBar : ITickable
    {
	    private readonly Slider _slider;
	    private readonly AudioSource _restorePowerAS;
	    
	    private RestorePowerBar(
		    Slider slider,
		    AudioSource restorePowerAS)
	    {
		    _slider = slider;
		    _restorePowerAS = restorePowerAS;
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