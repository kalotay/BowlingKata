namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }
        public int FrameScore { get; private set; }

        private bool _isBonus;

        public TenPinScorer()
        {
            Score = 0;
            FrameScore = 0;
            _isBonus = false;
        }

        public void Register(Roll roll)
        {
            if (roll is FirstRoll)
            {
                FrameScore = 0;
            }

            var score = roll.Score;
            FrameScore += score;
            Score += score;

            if (_isBonus)
            {
                Score += score;
            }

            _isBonus = FrameScore == 10;
        }
    }
}