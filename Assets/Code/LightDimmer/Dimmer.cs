using UnityEngine;

namespace Code
{
    public class Dimmer : MonoBehaviour 
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            var spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null) return;
            
            spriteRenderer.color = Color.black;
            
        }
    }
}
