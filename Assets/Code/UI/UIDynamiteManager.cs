using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
    public class UIDynamiteManager : IInitializable, ITickable
    {
        private readonly DynamiteCounter _dynamiteCounter;
        private readonly UIDynamite.Pool _uiDynamitePool;

        public UIDynamiteManager(
            DynamiteCounter dynamiteCounter,
            UIDynamite.Pool uiDynamitePool)
        {
            _dynamiteCounter = dynamiteCounter;
            _uiDynamitePool = uiDynamitePool;
        }

        private int _activeDynamites;
        private List<UIDynamite> _uiDynamites = new List<UIDynamite>();
        
        public void Initialize()
        {
            _activeDynamites = _dynamiteCounter.DynamitesLeft;
            SpawnDynamites();
        }

        public void Tick()
        {
            if (_activeDynamites == _dynamiteCounter.DynamitesLeft) return;
            
            DespawnDynamites();
                
            _activeDynamites -= 1;
            SpawnDynamites();
                
            _activeDynamites = _dynamiteCounter.DynamitesLeft;
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