using System;

namespace Code
{
    public class DynamiteCounter
    {
        private Settings _settings;

        public DynamiteCounter(Settings settings)
        {
            _settings = settings;
        }
        
        public int DynamitesLeft { get; private set; }
        
        public void ResetDynamiteCounter()
        {
            DynamitesLeft = _settings.TotalNumDynamites;
        }
        
        public void SubtractDynamite()
        {
            if (DynamitesLeft <=0) return;
            DynamitesLeft -= 1;
        }
        
        [Serializable]
        public class Settings
        {
            public int TotalNumDynamites;
        }
    }
}