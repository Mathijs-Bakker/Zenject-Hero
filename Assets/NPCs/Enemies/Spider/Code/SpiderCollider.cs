using Player.Code;
using UnityEngine;

namespace NPCs.Enemies.Spider.Code
{
    public class SpiderCollider : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            var player = other.gameObject.GetComponent<PlayerFacade>();
            if (player != null) player.Die();
        }
    }
}