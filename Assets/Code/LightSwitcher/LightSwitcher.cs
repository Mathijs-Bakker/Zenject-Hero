using UnityEngine;

namespace Code
{
    public class LightSwitcher : MonoBehaviour
    {
        private bool _lightsOn = true;

        public void SwitchLight()
        {
            _lightsOn = false;

            const float horizontalUnits = 12f;
            const float verticalUnits = 5f;
            
            var center = new Vector2(0, 3);
            var size = new Vector2(horizontalUnits, verticalUnits);
            const float angle = 0;
            
            var collider2Ds = Physics2D.OverlapBoxAll(center, size, angle);

            foreach (var collider2D in collider2Ds)
            {
                Obscure(collider2D);
            }
        }

        private void Obscure(Collider2D other)
        {
            var spriteRenderer = other.gameObject.GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer == null) return;

            if (other.gameObject.GetComponent<PlayerFacade>() ||
                other.gameObject.GetComponent<Killable>())
            {
                spriteRenderer.material.shader = Shader.Find("GUI/Text Shader");
                spriteRenderer.material.color = Color.blue;
            }
            else
            {
                spriteRenderer.material.shader = Shader.Find("GUI/Text Shader");
                spriteRenderer.color = Color.black;
            }
        }
    }
}
