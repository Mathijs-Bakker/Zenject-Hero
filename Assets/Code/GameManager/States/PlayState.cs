using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code
{
    public class PlayState : GameStateEntity
    {
//        private readonly PowerBarFacade _powerBarFacade;
//
//        public PlayState(PowerBarFacade powerBarFacade)
//        {
//            _powerBarFacade = powerBarFacade;
//        }
        
        public override void Initialize()
        {
            Debug.Log("GamePlayState: Initialized");
        }
        
        public override void Start()
        {
            SceneManager.LoadScene(1);
            Debug.Log("GamePlayState: Started");
        }
        
        public override void Tick()
        {
//            if (!_powerBarFacade.HasPowerBarRestored())
//            {
//                _powerBarFacade.StartCountDown();
//            }
        }
        
        public override void Dispose()
        {
            Debug.Log("GamePlayState: Disposed");
        }

        [Serializable]
        public class Settings
        {
            public PowerBarFacade PowerBarFacade;
        }

        public class Factory : Factory<PlayState>
        {
        }
    }
}