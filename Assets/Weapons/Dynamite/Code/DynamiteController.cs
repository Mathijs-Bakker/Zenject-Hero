using UnityEngine;
using Zenject;

namespace Weapons.Dynamite.Code
{
    public class DynamiteController : MonoBehaviour
    {
        private Pool _dynamitePool;
        private DynamiteModel _dynamiteModel;

        [Inject]
        public void Construct(Pool dynamitePool,
            DynamiteModel dynamiteModel)
        {
            _dynamitePool = dynamitePool;
            _dynamiteModel = dynamiteModel;
        }

        private void Update()
        {
            if(!_dynamiteModel.HasFinished) return;
            _dynamitePool.Despawn(this);
        }

        private bool IsFusing
        {
            set { _dynamiteModel.IsFusing = value; }
        }

        private bool IsExploding
        {
            set { _dynamiteModel.IsExploding = value; }
        }
        
        public class Pool : MonoMemoryPool<DynamiteController>
        {
            protected override void OnSpawned(DynamiteController dynamiteController)
            {
                dynamiteController.IsFusing = true;
                dynamiteController.IsExploding = false;
            }
        }
    }
}