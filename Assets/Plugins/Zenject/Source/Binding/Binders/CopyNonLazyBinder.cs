using ModestTree;
namespace Zenject
{
    public class CopyNonLazyBinder : NonLazyBinder
    {
        public CopyNonLazyBinder(BindInfo bindInfo)
            : base(bindInfo)
        {
        }

        public BindInfo SecondaryCopyBindInfo
        {
            get; set;
        }

        public NonLazyBinder CopyIntoAllSubContainers()
        {
            SetInheritanceMethod(BindingInheritanceMethods.CopyIntoAll);
            return this;
        }

        // Only copy the binding into children and not grandchildren
        public NonLazyBinder CopyIntoDirectSubContainers()
        {
            SetInheritanceMethod(BindingInheritanceMethods.CopyDirectOnly);
            return this;
        }

        // Do not apply the binding on the current container
        public NonLazyBinder MoveIntoAllSubContainers()
        {
            SetInheritanceMethod(BindingInheritanceMethods.MoveIntoAll);
            return this;
        }

        // Do not apply the binding on the current container
        public NonLazyBinder MoveIntoDirectSubContainers()
        {
            SetInheritanceMethod(BindingInheritanceMethods.MoveDirectOnly);
            return this;
        }

        void SetInheritanceMethod(BindingInheritanceMethods method)
        {
            BindInfo.BindingInheritanceMethod = method;

            if (SecondaryCopyBindInfo != null)
            {
                SecondaryCopyBindInfo.BindingInheritanceMethod = method;
            }
        }
    }
}
