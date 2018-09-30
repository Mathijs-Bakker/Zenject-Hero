using Code;
using Enemies.Contracts;
using UnityEngine;
using Zenject;

namespace Enemies.Spider.Code
{
	public class SpiderModel : Enemy
	{
		[Inject] private readonly SignalBus _signalBus;

		[SerializeField] private int _health = 50;
		[SerializeField] private int _scorePoints = 50;

		public override void ReceiveDamage(int damage)
		{
			_health -= damage;
			if (_health > 0) return;

			_signalBus.Fire(new UpdateScoreSignal(_scorePoints));
			Die();
		}

		public override void Die()
		{
			Destroy(gameObject);
		}
	}
}
