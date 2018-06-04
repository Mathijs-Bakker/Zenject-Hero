namespace Zenject
{
    public class IfNotBoundBinder
    {
        public IfNotBoundBinder(BindInfo bindInfo)
        {
            BindInfo = bindInfo;
        }

        protected BindInfo BindInfo
        {
            get;
            private set;
        }

        public void IfNotBound()
        {
            BindInfo.OnlyBindIfNotBound = true;
        }
    }
}

