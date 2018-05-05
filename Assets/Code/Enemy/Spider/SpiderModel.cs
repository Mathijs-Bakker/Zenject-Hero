using UnityEngine;
using Zenject;

namespace Code
{
	// Spider:
	// IS-A Enemy
	// HAS health
	// HAS-A Collider2D
	// kills player when colliding
	// HAS-A Animating behaviour

	public class SpiderModel : Killable
	{
		[Inject] private readonly UpdateScoreSignal _updateScoreSignal;

		[SerializeField] private int _health = 50;
		[SerializeField] private int _scorePoints = 50;

		public override void ReceiveDamage(int damage)
		{
			_health -= damage;
			Debug.Log(_health);
			if (_health > 0) return;

			_updateScoreSignal.Fire(_scorePoints);
			Die();
		}

		public override void Die()
		{
			Destroy(gameObject);
		}
	}
}
