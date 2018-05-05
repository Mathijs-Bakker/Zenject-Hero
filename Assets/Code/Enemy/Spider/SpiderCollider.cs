using UnityEngine;

namespace Code
{
    public class SpiderCollider : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider2D;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var player = other.gameObject.GetComponent<PlayerFacade>();
            if (player != null) player.Die();
        }
    }
}