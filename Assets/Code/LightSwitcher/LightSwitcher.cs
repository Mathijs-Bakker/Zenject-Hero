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
            Vector2 screenPos = 
                GetComponentInParent<FlipScreenManager>().transform.position;
            
            var collider2Ds = GetCollidingObjects(screenPos);

            foreach (var c in collider2Ds)
            {
                var spriteRenderer = c.gameObject.GetComponentInChildren<SpriteRenderer>();
                Obscure(spriteRenderer);
            }

            if (!_obsuredScreens.Contains(screenPos))
            {
                _obsuredScreens.Add(screenPos);
            }
        }

        private IEnumerable<Collider2D> GetCollidingObjects(Vector2 flipScreenPosition)
        {
            var boxOffset = new Vector2(0, 3);
            var boxCenterPos = flipScreenPosition + boxOffset;

            const float horizontalUnits = 12f;
            const float verticalUnits = 5f;
            var boxSize = new Vector2(horizontalUnits, verticalUnits);

            var collidingObjects = Physics2D.OverlapBoxAll(boxCenterPos, boxSize, 0);
            
            return collidingObjects;
        }

        private void Obscure(SpriteRenderer sprite)
        {
            if (sprite == null) return;

            if (sprite.gameObject.GetComponentInParent<PlayerFacade>() ||
                sprite.gameObject.GetComponentInParent<Killable>() ||
                sprite.gameObject.GetComponentInParent<Lamp>() ||
                sprite.gameObject.GetComponentInParent<Damageable>() ||
                sprite.gameObject.GetComponentInParent<Miner>())
            {
                sprite.material.shader = Shader.Find("GUI/Text Shader");
                sprite.material.color = Color.blue;
            }
            else
            {
                sprite.material.shader = Shader.Find("GUI/Text Shader");
                sprite.color = Color.black;
            }
        }

        private void SetPlayerShader()
        {
            var playerSprite = _playerFacade.GetComponentInChildren<SpriteRenderer>();
                
            if (_obsuredScreens.Contains(
                GetComponentInParent<FlipScreenManager>().transform.position))
            {
                Obscure(playerSprite);
            }
            else
            {
                playerSprite.material.shader = Shader.Find("Sprites/Default");
                playerSprite.material.color = Color.white;
            }
        }
    }
}
