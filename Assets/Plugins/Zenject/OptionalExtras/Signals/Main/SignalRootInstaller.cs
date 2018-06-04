using System;

namespace Zenject
{
    public class SignalRootInstaller : Installer<SignalRootInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SignalBus>().AsSingle().CopyIntoAllSubContainers();

            // Dispose last to ensure that we don't remove SignalSubscription before the user does
            Container.BindLateDisposableExecutionOrder<SignalBus>(-999);

            // Run async events at the beginning of the next frame
            Container.BindTickableExecutionOrder<SignalBus>(-1);
        }
    }
}
