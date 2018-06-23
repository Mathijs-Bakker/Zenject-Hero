using UnityEngine;

namespace Code
{
    public class PlayerStateSpawning : PlayerState
    {
        private readonly PlayerModel _playerModel;
        private readonly Rigidbody2D _rigidbody2D;

        public PlayerStateSpawning(
            PlayerModel playerModel,
            Rigidbody2D rigidbody2D)
        {
            _playerModel = playerModel;
            _rigidbody2D = rigidbody2D;
        }

        public override void Start()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
        
        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}