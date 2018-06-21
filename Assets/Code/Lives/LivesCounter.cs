using System;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Code
{
    public class LivesCounter
    {
        private Settings _settings;

        public LivesCounter(Settings settings)
        {
            _settings = settings;
        }
        
        public int LivesLeft { get; private set; }
        
        public void ResetLivesCounter()
        {
            LivesLeft = _settings.TotalNumLives;
        }
        
        public void SubtractLive()
        {
            if (LivesLeft <=0) return;
            LivesLeft -= 1;
        }

        public void AddLive()
        {
            if (LivesLeft <= 0) return;
            LivesLeft += 1;
        }
        
        [Serializable]
        public class Settings
        {
            [Header("Value change does not take effect in runtime")]
            public int TotalNumLives;
        }
    }
}