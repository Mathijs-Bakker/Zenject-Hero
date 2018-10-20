using System;
using UnityEngine;
using Zenject;

namespace Weapons.Dynamite.Code
{
    public class DynamiteFuse : IInitializable, ITickable
    {
        private readonly Settings _settings;
        private readonly DynamiteModel _dynamiteModel;

        public DynamiteFuse(Settings settings, DynamiteModel dynamiteModel)
        {
            _settings = settings;
            _dynamiteModel = dynamiteModel;
        }
        
        private float _fuseTime;

        public void Initialize()
        {
            ResetTimer();
        }
        
        public void Tick()
        {
            if(!_dynamiteModel.IsFusing) return;
            FuseTimer();
        }
        
        private void FuseTimer()
        {
            if (_fuseTime <= 0)
            {
                _dynamiteModel.IsFusing = false;
                _dynamiteModel.IsExploding = true;
                ResetTimer();
                return;
            }
            
            _fuseTime -= Time.deltaTime;
        }
        
        private void ResetTimer()
        {
            _fuseTime = _settings.fuseTimeInSeconds;
        }

        [Serializable]
        public class Settings
        {
            public float fuseTimeInSeconds;
        }
    }
}