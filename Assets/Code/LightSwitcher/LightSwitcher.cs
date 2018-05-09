using System.Collections.Generic;
using Code.FlipScreen;
using UnityEngine;
using Zenject;

namespace Code
{
    public class LightSwitcher : MonoBehaviour
    {
        private List<Vector2> _obsuredScreens = new List<Vector2>();

        [Inject] private PlayerFacade _playerFacade;

        private void Update()
        {
            SetPlayerShader();
        }

        public void SwitchLight()
        {
            Vector2 flipScreenPosition = GetComponentInParent<FlipScreenManager>().transform.position;
            var boxOffset = new Vector2(0, 3);
            var boxCenterPos = flipScreenPosition + boxOffset;

            const float horizontalUnits = 12f;
            const float verticalUnits = 5f;
            var boxSize = new Vector2(horizontalUnits, verticalUnits);
            
            var collider2Ds = Physics2D.OverlapBoxAll(boxCenterPos, boxSize, 0);

            foreach (var col2D in collider2Ds)
            {
                Obscure(col2D);
            }

            if (!_obsuredScreens.Contains(flipScreenPosition))
            {
                _obsuredScreens.Add(flipScreenPosition);
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

        public void SetPlayerShader()
        {
            var spriteRenderer = _playerFacade.GetComponentInChildren<SpriteRenderer>();
                
            if (_obsuredScreens.Contains(
                GetComponentInParent<FlipScreenManager>().transform.position))
            {
                spriteRenderer.material.shader = Shader.Find("GUI/Text Shader");
                spriteRenderer.material.color = Color.blue;
            }
            else
            {
                spriteRenderer.material.shader = Shader.Find("Sprites/Default");
                spriteRenderer.material.color = Color.white;
            }
        }
    }
}
