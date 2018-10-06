using System.Collections.Generic;
using Zenject;

namespace Code
{
    public class UIDynamitesManager : IInitializable, ITickable
    {
        private readonly DynamitesCounter _dynamitesCounter;
        private readonly UIDynamite.Pool _uiDynamitePool;

        public UIDynamitesManager(
            DynamitesCounter dynamitesCounter,
            UIDynamite.Pool uiDynamitePool)
        {
            _dynamitesCounter = dynamitesCounter;
            _uiDynamitePool = uiDynamitePool;
        }

        private int _activeDynamites;
        private List<UIDynamite> _uiDynamites = new List<UIDynamite>();
        
        public void Initialize()
        {
            _activeDynamites = _dynamitesCounter.DynamitesLeft;
            SpawnDynamites();
        }

        public void Tick()
        {
            if (_activeDynamites == _dynamitesCounter.DynamitesLeft) return;
            
            DespawnDynamites();
                
            _activeDynamites -= 1;
            SpawnDynamites();
                
            _activeDynamites = _dynamitesCounter.DynamitesLeft;
        }

        private void DespawnDynamites()
        {
            foreach (var uiDynamite in _uiDynamites)
            {
                _uiDynamitePool.Despawn(uiDynamite);
            }
            _uiDynamites.Clear();
        }

        private void SpawnDynamites()
        {
            for (var i = 0; i < _activeDynamites; i++)
            {
                var uiDynamite = _uiDynamitePool.Spawn();
                _uiDynamites.Add(uiDynamite);
            }
        }
    }
}