using UnityEngine;

namespace Code
{
    public class Player 
    {
        private readonly Rigidbody2D _rigidBody;
        private readonly Collider2D _collider;
        private readonly SpriteRenderer _spriteRenderer;
        public readonly Animator Animator;

        float _health = 100.0f;

        public Player(
            Rigidbody2D rigidbody2D,
            Collider2D collider2D,
            SpriteRenderer spriteRenderer,
            Animator animator)
        {
            _rigidBody = rigidbody2D;
            _collider = collider2D;
            _spriteRenderer = spriteRenderer;
            Animator = animator;
        }
        
        public float Health
        {
            get { return _health; }
        }

        public bool IsDead { get; set; }
        
        public Vector2 Position
        {
            get { return _rigidBody.position; }
            set { _rigidBody.position = value; }
        }
        
        public void AddForce(Vector2 force)
        {
            _rigidBody.AddForce(force);
        }

        public bool IsGrounded { get; set; }

        public void IsFacingLeft(bool isMovingToLeftDirection)
        {
            _spriteRenderer.flipX = isMovingToLeftDirection;
        }
    }
}
