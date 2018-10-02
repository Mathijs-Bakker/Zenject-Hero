using System;
using UnityEngine;
using Zenject;

namespace Code
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Ultimate Hero/GameSettings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameInstaller.Settings GameInstaller;
//        public PlayerSettings Player;
        public LivesSettings Lives;
        public DynamiteSettings Dynamite;
//        public LaserSettings Laser;
        public GameStateSettings GameState;


//        [Serializable]
//        public class PlayerSettings
//        {
//            public PlayerMovement.Settings Movement;
//        }
        
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

//        [Serializable]
//        public class LaserSettings
//        {
//            public Laser.Code.Laser.Settings Damage;
//        }
        
        [Serializable]
        public class GameStateSettings
        {
        }
        
        public override void InstallBindings()
        {
            Container.BindInstance(GameInstaller).IfNotBound();
//            Container.BindInstance(Player.Movement);
            Container.BindInstance(Lives.TotalNumLives);
            Container.BindInstance(Dynamite.TotalNumDynamites);
//            Container.BindInstance(Laser.Damage);
        }
    }
}
