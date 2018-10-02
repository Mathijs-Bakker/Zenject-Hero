using System;
using Code;
using UnityEngine;
using Zenject;

namespace Player.Code.Installers
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
    public class PlayerSettingsInstaller : ScriptableObjectInstaller<PlayerSettingsInstaller>
    {
        public PlayerPrefabInstaller.Settings PlayerPrefabInstaller;
        public PlayerSettings Player;

        [Serializable]
        public class PlayerSettings
        {
            public PlayerMovement.Settings Movement;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(PlayerPrefabInstaller).IfNotBound();
            Container.BindInstance(Player.Movement);
        }
    }
}