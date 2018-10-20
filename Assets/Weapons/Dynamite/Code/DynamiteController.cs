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

        private void Start()
        {
            IsFusing(true);
        }

        private void Update()
        {
            _dynamiteModel.IsFusing = true;
            Despawn();
        }

        private void Despawn()
        {
            if (!_dynamiteModel.HasFinished) return;
            _dynamitePool.Despawn(this);
        }

        private void IsFusing(bool b)
        {
            _dynamiteModel.IsFusing = b;
        }

        private bool IsExploding
        {
            set { _dynamiteModel.IsExploding = value; }
        }
        
        public class Pool : MonoMemoryPool<DynamiteController>
        {
            protected override void Reinitialize(DynamiteController dynamiteController)
            {
                dynamiteController.IsFusing(true);
                dynamiteController.IsExploding = false;
            }
        }
    }
}