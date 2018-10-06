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
                    _settings.Slider);
        }

        [Serializable]
        public class Settings
        {
            public Slider Slider;
        }
    }
}