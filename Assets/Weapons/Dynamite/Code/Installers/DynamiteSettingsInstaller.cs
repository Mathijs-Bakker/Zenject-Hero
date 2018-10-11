using UnityEngine;
using Zenject;

namespace Weapons.Dynamite.Code.Installers
{
    [CreateAssetMenu(fileName = "DynamiteSettings", menuName = "Scriptable Objects/DynamiteSettingsInstaller")]
    public class DynamiteSettingsInstaller : ScriptableObjectInstaller<DynamiteSettingsInstaller>
    {
        public DynamitePoolInstaller.Settings DynamitePool;

        public override void InstallBindings()
        {
            Container.BindInstance(DynamitePool).IfNotBound();
        }
    }
}