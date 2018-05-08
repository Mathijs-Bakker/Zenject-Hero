using UnityEngine;

namespace Code
{
    public class Dimmer : MonoBehaviour
    {
        private bool _lightsOff;

        public void SwitchLight()
        {
            _lightsOff = true;
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!_lightsOff) return;
            
            var spriteRenderer = other.gameObject.GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer == null) return;

            if (other.gameObject.GetComponent<PlayerFacade>())
            {
                spriteRenderer.material.color = Color.blue;
                spriteRenderer.material.shader = Shader.Find("GUI/Text Shader");
            }
            else
            {
                spriteRenderer.color = Color.black;
            }

            _lightsOff = false;
        }
    }
}
