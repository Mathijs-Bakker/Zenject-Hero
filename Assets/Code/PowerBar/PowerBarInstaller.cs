using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class PowerBarInstaller : MonoInstaller
    {
        [SerializeField] private Settings _settings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PowerBar>()
                .AsSingle()
                .WithArguments(_settings.Slider);

            Container.BindInterfacesAndSelfTo<RestorePowerBar>()
                .AsSingle()
                .WithArguments(
                    _settings.Slider,
                    _settings.RestorePowerAS);

            Container.BindSignal<StartPowerBarSignal>()
                .To<PowerBarFacade>(x => x.StartCountDown)
                .FromComponentInHierarchy();
        }

        [Serializable]
        public class Settings
        {
            public AudioSource RestorePowerAS;
            public Slider Slider;
        }
    }
}