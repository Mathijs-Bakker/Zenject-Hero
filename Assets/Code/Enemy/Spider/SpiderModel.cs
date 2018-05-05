using UnityEngine;
using Zenject;

namespace Code
{
	public class SpiderModel : Killable
	{
		[Inject] private readonly UpdateScoreSignal _updateScoreSignal;

		[SerializeField] private int _health = 50;
		[SerializeField] private int _scorePoints = 50;

		public override void ReceiveDamage(int damage)
		{
			_health -= damage;
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
