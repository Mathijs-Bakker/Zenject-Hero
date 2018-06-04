using System.Collections.Generic;
using ModestTree;

namespace Zenject
{
    public class SignalCopyBinder
    {
        readonly BindInfo[] _bindInfos;

        public SignalCopyBinder(params BindInfo[] bindInfos)
        {
            _bindInfos = bindInfos;
        }

        public void CopyIntoAllSubContainers()
        {
            SetInheritanceMethod(BindingInheritanceMethods.CopyIntoAll);
        }

        // Only copy the binding into children and not grandchildren
        public void CopyIntoDirectSubContainers()
        {
            SetInheritanceMethod(BindingInheritanceMethods.CopyDirectOnly);
        }

        // Do not apply the binding on the current container
        public void MoveIntoAllSubContainers()
        {
            SetInheritanceMethod(BindingInheritanceMethods.MoveIntoAll);
        }

        // Do not apply the binding on the current container
        public void MoveIntoDirectSubContainers()
        {
            SetInheritanceMethod(BindingInheritanceMethods.MoveDirectOnly);
        }

        void SetInheritanceMethod(BindingInheritanceMethods method)
        {
            for (int i = 0; i < _bindInfos.Length; i++)
            {
                _bindInfos[i].BindingInheritanceMethod = method;
            }
        }
    }
}
