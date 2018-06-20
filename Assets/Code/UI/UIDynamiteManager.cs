using UnityEngine;
using Zenject;

namespace Code
{
    public class UIDynamiteManager : IInitializable
    {
        private readonly UIDynamite.Factory _uiDynamiteFactory;

        public UIDynamiteManager(UIDynamite.Factory uiDynamiteFactory)
        {
            _uiDynamiteFactory = uiDynamiteFactory;
        }
        
        public void Initialize()
        {
            for (var i = 0; i < 6; i++)
            {
                var uiDynamite = _uiDynamiteFactory.Create();
            
                uiDynamite.transform.localPosition = new Vector2(i * 30f, 0);
            }
        }
    }
}