using UnityEngine;
using Zenject;

namespace Code
{
	public class SpiderModel : Killable
	{
//		[Inject] private readonly UpdateScoreSignal _updateScoreSignal;
//		private readonly UpdateScoreSignal _updateScoreSignal;
//		
//		public SpiderModel(UpdateScoreSignal signal)
//		{
//			_updateScoreSignal = signal;
//		}
		
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
