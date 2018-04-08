using UnityEngine;
using Zenject;

namespace Code
{
    public class CaveIn : Damageable
    {
        [SerializeField] private int _health;
        [SerializeField] private int _scorePoints = 50;
        [SerializeField] private int _dynamitePoints = 75;
        
        private UpdateScoreSignal _updateScoreSignal;

        [Inject]
        private CaveIn(UpdateScoreSignal updateScoreSignal)
        {
            _updateScoreSignal = updateScoreSignal;
        }

        public override void ReceiveDamage(int damage)
        {

            _health -= damage;

            if (_health <= 0)
            {
                _updateScoreSignal.Fire(_scorePoints);
                Destroy(gameObject);
            }
        }

        public override void BlowUp()
        {
            _updateScoreSignal.Fire(_dynamitePoints);
            Destroy(gameObject);
        }
    }
}