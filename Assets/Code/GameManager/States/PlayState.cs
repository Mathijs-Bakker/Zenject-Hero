using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayState : GameStateEntity
    {
        public override void Initialize()
        {
            Debug.Log("GamePlayState: Initialized");
        }

        public override void Start()
        {
            Debug.Log("GamePlayState: Started");
        }

        public override void Tick()
        {
        }

        public override void Dispose()
        {
            Debug.Log("GamePlayState: Disposed");
        }

        public class Factory : Factory<PlayState>
        {
        }
    }
}