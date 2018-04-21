using System;
using UnityEngine;
using Zenject;

namespace Code
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Ultimate Hero/GameSettings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameStateSettings GameState;

        public LaserSettings Laser;

        public PlayerSettings Player;

        public override void InstallBindings()
        {
            Container.BindInstance(Player.Movement);

            Container.BindInstance(Laser.Damage);
        }

        [Serializable]
        public class GameStateSettings
        {
        }

        [Serializable]
        public class PlayerSettings
        {
            public PlayerMovementHandler.Settings Movement;
        }

        [Serializable]
        public class LaserSettings
        {
            public Laser.Settings Damage;
        }
    }
}