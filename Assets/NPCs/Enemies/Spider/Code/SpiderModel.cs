using NPCs.Enemies.Contracts;
using UI.Score.Code;
using UnityEngine;
using Zenject;

namespace NPCs.Enemies.Spider.Code
{
    public class SpiderModel : Killable
    {
        [Inject] private readonly SignalBus _signalBus = null;

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