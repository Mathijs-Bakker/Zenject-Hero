using UnityEngine;

namespace Code
{
    public class ConcreteTile : MonoBehaviour
    {
        [Header("Selector:")]
        [SerializeField] private bool _isWalkable;

        [Header("Required Fields:")] 
        [SerializeField] private Collider2D _mainTileCollider;
        [SerializeField] private GameObject _walkableSurface;

        private void Awake()
        {
            if (_walkableSurface != null)
            {
                _mainTileCollider.enabled = !_isWalkable;
                _walkableSurface.gameObject.SetActive(_isWalkable);
            }
            else
            {
                Debug.LogError("Concrete Tile:  Missing child object.\n" + 
                                "Patch child object: 'Walkable Surface'" +
                                "to field: Walkable Surface in the inspector.");
            }
        }
    }
}
