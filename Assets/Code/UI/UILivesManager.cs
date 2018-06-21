using System.Collections.Generic;
using Zenject;

namespace Code
{
    public class UILivesManager : IInitializable, ITickable
    {
        private readonly LivesCounter _livesCounter;
        private readonly UILife.Pool _uiLivePool;

        public UILivesManager(
            LivesCounter livesCounter,
            UILife.Pool uiLivePool)
        {
            _livesCounter = livesCounter;
            _uiLivePool = uiLivePool;
        }

        private int _activeLives;
        private List<UILife> _uiLives = new List<UILife>();
        
        public void Initialize()
        {
            _activeLives = _livesCounter.LivesLeft;
            SpawnLives();
        }

        public void Tick()
        {
            if (_activeLives == _livesCounter.LivesLeft) return;
            
            DespawnLives();
                
            _activeLives -= 1;
            SpawnLives();
                
            _activeLives = _livesCounter.LivesLeft;
        }

        private void DespawnLives()
        {
            foreach (var uiLife in _uiLives)
            {
                _uiLivePool.Despawn(uiLife);
            }
            _uiLives.Clear();
        }

        private void SpawnLives()
        {
            for (var i = 0; i < _activeLives; i++)
            {
                var uiLife = _uiLivePool.Spawn();
                _uiLives.Add(uiLife);
            }
        }
    }
}