using Zenject;

namespace Code
{
    public class UpdateScoreSignal : ISignal
    {
        public UpdateScoreSignal(int scorepoints)
        {
            ScorePoints = scorepoints;
        }

        public int ScorePoints
        {
            get; private set;
        }
    }
}