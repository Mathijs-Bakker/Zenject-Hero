using System.Collections.Generic;
using Code;
using GameSystem.Dynamites;
using Weapons.Dynamite.Code;
using Zenject;

namespace UI.Dynamites.Code
{
    public class UIDynamitesManager : IInitializable, ITickable
    {
        private readonly DynamitesCount _dynamitesCount;
        private readonly UIDynamite.Pool _uiDynamitePool;

        private int _activeDynamites;
        private readonly List<UIDynamite> _uiDynamites = new List<UIDynamite>();

        public UIDynamitesManager(
            DynamitesCount dynamitesCount,
            UIDynamite.Pool uiDynamitePool)
        {
            _dynamitesCount = dynamitesCount;
            _uiDynamitePool = uiDynamitePool;
        }

        public void Initialize()
        {
            _activeDynamites = _dynamitesCount.DynamitesLeft;
            SpawnDynamites();
        }

        public void Tick()
        {
            if (_activeDynamites == _dynamitesCount.DynamitesLeft) return;

            DestroyDynamite();

            _activeDynamites -= 1;
            SpawnDynamites();

            _activeDynamites = _dynamitesCount.DynamitesLeft;
        }

        private void DestroyDynamite()
        {
            foreach (var uiDynamite in _uiDynamites) _uiDynamitePool.Despawn(uiDynamite);
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