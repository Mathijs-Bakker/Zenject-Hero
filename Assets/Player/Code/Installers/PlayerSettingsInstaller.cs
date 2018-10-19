using System;
using Code;
using UnityEngine;
using Zenject;

namespace Player.Code.Installers
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
    public class PlayerSettingsInstaller : ScriptableObjectInstaller<PlayerSettingsInstaller>
    {
        public PlayerSettings player;
        public PlayerPrefabInstaller.Settings playerPrefabInstaller;

        public override void InstallBindings()
        {
            Container.BindInstance(playerPrefabInstaller).IfNotBound();
            Container.BindInstance(player.movement);
        }

        [Serializable]
        public class PlayerSettings
        {
            public PlayerMovement.Settings movement;
        }
    }
}