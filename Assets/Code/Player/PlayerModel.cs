using UnityEngine;

namespace Code
{
    public class PlayerModel
    {
        private readonly Collider2D _collider;
        private readonly Rigidbody2D _rigidBody;
        private readonly SpriteRenderer _spriteRenderer;
        public readonly Animator Animator;

        public PlayerModel(
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

        public bool IsDead { get; set; }

        public Vector2 Position
        {
            get { return _rigidBody.position; }
            set { _rigidBody.position = value; }
        }

        public bool IsGrounded { get; set; }

        public bool HasMoved { get; set; }

        
        public void AddForce(Vector2 force)
        {
            _rigidBody.AddForce(force);
        }
        public bool IsFacingLeft { get; private set; }

        public void FaceLeft(bool isPlayerMovingToTheLeft)
        {
            _spriteRenderer.flipX = isPlayerMovingToTheLeft;
            IsFacingLeft = isPlayerMovingToTheLeft;
        }
    }
}