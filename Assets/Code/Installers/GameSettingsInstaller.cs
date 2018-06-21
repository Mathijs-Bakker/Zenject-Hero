using System;
using UnityEngine;
using Zenject;

namespace Code
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Ultimate Hero/GameSettings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameInstaller.Settings GameInstaller;
        public PlayerSettings Player;
        public DynamiteSettings Dynamite;
        public LaserSettings Laser;
        public GameStateSettings GameState;


        [Serializable]
        public class PlayerSettings
        {
            public PlayerMovementHandler.Settings Movement;
        }

        [Serializable]
        public class DynamiteSettings
        {
            [Header("Restart game to take effect:")]
            public DynamitesCounter.Settings TotalNumDynamites;
        }

        [Serializable]
        public class LaserSettings
        {
            public Laser.Settings Damage;
        }
        
        [Serializable]
        public class GameStateSettings
        {
        }
        
        public override void InstallBindings()
        {
            Container.BindInstance(GameInstaller).IfNotBound();
            Container.BindInstance(Player.Movement);
//            Container.BindInstance(LivesCounter.L)
            Container.BindInstance(Dynamite.TotalNumDynamites);
            Container.BindInstance(Laser.Damage);
        }
    }
}
