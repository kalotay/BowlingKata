namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        private int _previousScore;
        private int _scoreMultiplier;
        public int Score { get; private set; }

        public TenPinScorer()
        {
            Score = 0;
            _scoreMultiplier = 1;
        }

        public void Register(object roll)
        {
            var score = (int) roll;

            Score += _scoreMultiplier * score;

            _scoreMultiplier = (score + _previousScore) == 10 ? 2 : 1;

            _previousScore = score;
        }
    }
}