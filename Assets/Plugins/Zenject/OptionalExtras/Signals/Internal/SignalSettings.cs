using System;

namespace Zenject
{
    [Serializable]
    public class SignalSettings
    {
        public static readonly SignalSettings Default = new SignalSettings();

        public bool AddAssertsForStrictDestructionOrder = false;
        public bool AutoUnsubscribeInDispose = true;
    }
}
