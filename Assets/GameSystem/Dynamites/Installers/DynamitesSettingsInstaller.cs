using System;
using UnityEngine;
using Zenject;

namespace GameSystem.Dynamites.Installers
{
    [CreateAssetMenu(fileName = "DynamitesSystemSettings", menuName = "Scriptable Objects/DynamiteSystemSettings")]
    public class DynamitesSettingsInstaller : ScriptableObjectInstaller<DynamitesSettingsInstaller>
    {
        public DynamitesSettings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings.totalNumDynamites);
            Container.BindInstance(settings.maximumActiveDynamites);
        }

        [Serializable]
        public class DynamitesSettings
        {
            public DynamitesCount.Settings totalNumDynamites;
            public DynamitesController.Settings maximumActiveDynamites;
        }
    }
}