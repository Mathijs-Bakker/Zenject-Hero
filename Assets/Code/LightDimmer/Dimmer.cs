using UnityEngine;

namespace Code
{
    public class Dimmer : MonoBehaviour
    {
        private bool _lightsOn = true;

        public void SwitchLight()
        {
            _lightsOn = false;
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (_lightsOn) return;
            
            var spriteRenderer = other.gameObject.GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer == null) return;

            if (other.gameObject.GetComponent<PlayerFacade>())
            {
                spriteRenderer.material.color = Color.blue;
                spriteRenderer.material.shader = Shader.Find("GUI/Text Shader");
            }
            else
            {
                Debug.Log("ffaf");
                spriteRenderer.color = Color.black;
            }

            _lightsOn = true;
        }
    }
}
