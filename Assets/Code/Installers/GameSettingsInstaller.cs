using System;
using Code.Installers;
using UnityEngine;
using Zenject;

namespace Code
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Ultimate Hero/GameSettings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public LivesSettings Lives;
        public DynamiteSettings Dynamite;
        public GameStateSettings GameState;

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
        
        public override void InstallBindings()
        {
            Container.BindInstance(Lives.TotalNumLives);
            Container.BindInstance(Dynamite.TotalNumDynamites);
        }
    }
}
