using UnityEngine;

namespace Player.Code
{
    public class PlayerPhysics
    {
        private readonly Rigidbody2D _rigidbody2D;

        public PlayerPhysics(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void GravityOn()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        public void GravityOff()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
    }
}