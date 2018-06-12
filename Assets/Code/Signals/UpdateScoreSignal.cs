using Zenject;

namespace Code
{
    public class UpdateScoreSignal : ISignal
    {
        public UpdateScoreSignal(int scorePoints)
        {
            ScorePoints = scorePoints;
        }

        public int ScorePoints
        {
            get; private set;
        }
    }
}