using UnityEngine;

namespace Code
{
    public class PlayerModel
    {
        private readonly Rigidbody2D _rigidBody;
        private readonly SpriteRenderer _spriteRenderer;

        public PlayerModel(
            Rigidbody2D rigidbody2D,
            SpriteRenderer spriteRenderer)
        {
            _rigidBody = rigidbody2D;
            _spriteRenderer = spriteRenderer;
        }

        public bool IsSpawning { get; set; }
        public bool IsReady { get; private set; }
        public bool IsMoving { get; set; }
        public bool IsFlying { get; set; }
        public bool IsRunning { get; set; }
        public bool IsGrounded { get; set; }
        public bool IsDead { get; set; }

        public Vector2 Position
        {
            get { return _rigidBody.position; }
            private set { _rigidBody.position = value; }
        }

        public bool IsFacingLeft { get; private set; }

        public void PlayerReady()
        {
            IsReady = true;
        }

        public void AddForce(Vector2 force)
        {
            _rigidBody.AddForce(force);
        }

        public void FaceLeft(bool isPlayerMovingToTheLeft)
        {
            _spriteRenderer.flipX = isPlayerMovingToTheLeft;
            IsFacingLeft = isPlayerMovingToTheLeft;
        }
    }
}