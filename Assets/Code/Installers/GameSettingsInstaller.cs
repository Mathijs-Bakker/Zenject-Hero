using System;
using UnityEngine;
using Zenject;

namespace Code
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Ultimate Hero/GameSettings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public DynamiteSettings Dynamite;
        public GameStateSettings GameState;
        public LivesSettings Lives;

        public override void InstallBindings()
        {
            Container.BindInstance(Lives.TotalNumLives);
            Container.BindInstance(Dynamite.TotalNumDynamites);
        }

        [Serializable]
        public class LivesSettings
        {
            public LivesCounter.Settings TotalNumLives;
        }

        [Serializable]
        public class DynamiteSettings
        {
            public DynamitesCounter.Settings TotalNumDynamites;
        }

        [Serializable]
        public class GameStateSettings
        {
        }
    }
}