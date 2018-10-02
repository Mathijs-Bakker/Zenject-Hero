using CaveIn.Contracts;
using Code;
using UnityEngine;
using Zenject;

namespace CaveIn.Code
{
    public class CaveIn : Explodable
    {
        [Inject] private readonly SignalBus _signalBus = null;

        [SerializeField] private int _dynamitePoints = 75;
        [SerializeField] private int _health;
        [SerializeField] private int _scorePoints = 50;

        public override void ReceiveDamage(int damage)
        {
            _health -= damage;
            if (_health > 0) return;

            _signalBus.Fire(new UpdateScoreSignal(_scorePoints));
            Destroy(gameObject);
        }

        public override void BlowUp()
        {
            _signalBus.Fire(new UpdateScoreSignal(_dynamitePoints));
            Destroy(gameObject);
        }
    }
}