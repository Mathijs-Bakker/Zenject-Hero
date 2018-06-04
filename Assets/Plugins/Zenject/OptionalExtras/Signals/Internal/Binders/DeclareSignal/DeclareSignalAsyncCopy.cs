using System;
using ModestTree;

namespace Zenject
{
    public class DeclareSignalAsyncCopyBinder : SignalCopyBinder
    {
        public DeclareSignalAsyncCopyBinder(SignalDeclarationBindInfo signalBindInfo, BindInfo bindInfo)
            : base(bindInfo)
        {
            SignalBindInfo = signalBindInfo;
        }

        protected SignalDeclarationBindInfo SignalBindInfo
        {
            get; private set;
        }

        public SignalCopyBinder RunAsync()
        {
            SignalBindInfo.RunAsync = true;
            return this;
        }
    }
}

