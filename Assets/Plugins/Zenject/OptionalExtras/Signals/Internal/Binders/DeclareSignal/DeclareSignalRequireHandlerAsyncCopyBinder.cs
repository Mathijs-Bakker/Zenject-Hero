using System;
using ModestTree;

namespace Zenject
{
    public class DeclareSignalRequireHandlerAsyncCopyBinder : DeclareSignalAsyncCopyBinder
    {
        public DeclareSignalRequireHandlerAsyncCopyBinder(
            SignalDeclarationBindInfo signalBindInfo, BindInfo bindInfo)
            : base(signalBindInfo, bindInfo)
        {
        }

        public DeclareSignalAsyncCopyBinder RequireHandler()
        {
            SignalBindInfo.RequireHandler = true;
            return this;
        }
    }
}

