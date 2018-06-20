using UnityEngine;
using Zenject;

namespace Code
{
    public class UIDynamiteManager : IInitializable
    {
        private readonly UIDynamite.Pool _uiDynamiteFactory;

        public UIDynamiteManager(UIDynamite.Pool uiDynamiteFactory)
        {
            _uiDynamiteFactory = uiDynamiteFactory;
        }
        
        public void Initialize()
        {
            for (var i = 0; i < 6; i++)
            {
                var uiDynamite = _uiDynamiteFactory.Spawn();
            
                uiDynamite.transform.localPosition = new Vector2(i * 30f, 0);
            }
        }
    }
}