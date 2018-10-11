using System;
using UnityEngine;

namespace Weapons.Dynamite.Code
{
    public class DynamitesCounter
    {
        private readonly Settings _settings;

        public DynamitesCounter(Settings settings)
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
            if (DynamitesLeft <= 0) return;
            DynamitesLeft -= 1;
        }

        [Serializable]
        public class Settings
        {
            [Header("Value change does not take effect in runtime")]
            public int TotalNumDynamites;
        }
    }
}