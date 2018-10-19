using System;
using UnityEngine;

namespace GameSystem.Dynamites
{
    public class DynamitesCount
    {
        private readonly Settings _settings;

        public DynamitesCount(Settings settings)
        {
            _settings = settings;
        }

        public int DynamitesLeft { get; private set; }

        public void ResetDynamiteCounter()
        {
            DynamitesLeft = _settings.totalNumDynamites;
        }

        public void SubtractDynamite()
        {
            if (DynamitesLeft <= 0) return;
            DynamitesLeft -= 1;
        }

        [Serializable]
        public class Settings
        {
            [Header("Value change does not take effect in runtime")]
            public int totalNumDynamites;
        }
    }
}