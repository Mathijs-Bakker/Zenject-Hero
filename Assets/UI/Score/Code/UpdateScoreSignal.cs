namespace UI.Score.Code
{
    public class UpdateScoreSignal
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