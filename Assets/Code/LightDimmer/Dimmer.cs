using UnityEngine;

namespace Code
{
    public class Dimmer : MonoBehaviour 
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log("Froot");
            var spriteRenderer = other.gameObject.GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer == null) return;

            if (other.gameObject.GetComponent<PlayerFacade>())
            {
//                spriteRenderer.color = Color.blue;
                spriteRenderer.material.color = Color.blue;
                spriteRenderer.material.shader = Shader.Find("GUI/Text Shader");
                Debug.Log("grey");
            }
            else
            {
                spriteRenderer.color = Color.black;
                Debug.Log("black");
            }
            
            Debug.Log("Whoot");
            
        }
    }
}
