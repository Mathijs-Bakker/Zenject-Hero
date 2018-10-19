using System;
using Zenject;

namespace GameSystem.Dynamites
{
    public class DynamitesController : ITickable
    {
        public bool HasMaxAmountExceeded { get; private set; }
        private int _currentActiveDynamites;
        private readonly int _nActiveDynamitesAllowed;
//        private readonly Settings _settings;

        public DynamitesController(Settings settings)
        {
//            _settings = settings;
            _nActiveDynamitesAllowed = settings.maximumActiveDynamites;
        }

//        public void Initialize()
//        {
//            _nActiveDynamitesAllowed = _settings.maximumActiveDynamites;
//        }
        
        public void Tick()
        {
            HasMaxAmountExceeded = _currentActiveDynamites >= _nActiveDynamitesAllowed;
        }

        public void NewActiveDynamite()
        {
            _currentActiveDynamites += 1;
        }

        public void DynamiteExploded()
        {
            _currentActiveDynamites -= 1;
        }

        [Serializable]
        public class Settings
        {
            public int maximumActiveDynamites;
        }

    }
}