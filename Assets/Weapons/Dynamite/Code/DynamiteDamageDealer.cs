using Explodables.CaveIn.Contracts;
using Player.Code;
using UnityEngine;
using Zenject;

namespace Weapons.Dynamite.Code
{
    public class DynamiteDamageDealer : ITickable
    {
        private readonly Collider2D _dynamiteCollider;
        private readonly DynamiteModel _dynamiteModel;

        public DynamiteDamageDealer(Collider2D collider2D,
            DynamiteModel dynamiteModel)
        {
            _dynamiteCollider = collider2D;
            _dynamiteModel = dynamiteModel;
        }

        public void Tick()
        {
            if(!_dynamiteModel.HasFinished) return;
            HandleCollidingGameObjects();
        }

        private void HandleCollidingGameObjects()
        {
            const int maxCollidersToFetch = 20;
            var overlappingColliders = new Collider2D[maxCollidersToFetch];
            
            var colliderCount = _dynamiteCollider.OverlapCollider(new ContactFilter2D(), overlappingColliders);
            
            if (colliderCount == 0) return;

            for (var i = 0; i < colliderCount; i++)
            {
                var go = overlappingColliders[i];

                DestroyExplodableGameObjects(go);
                KillPlayer(go);
            }
        }

        private static void KillPlayer(Collider2D go)
        {
            var player = go.GetComponent<PlayerFacade>();
            if (player != null) player.Die();
        }

        private static void DestroyExplodableGameObjects(Collider2D go)
        {
            var explodableGo = go.GetComponent<Explodable>();
            if (explodableGo != null)
            {
                explodableGo.BlowUp();
            }
        }

    }
}