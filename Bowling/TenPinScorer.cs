namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }
        public int FrameScore { get; private set; }

        private int _rollCount;
        private bool _isBonus;

        public TenPinScorer()
        {
            Score = 0;
            FrameScore = 0;
            _rollCount = 0;
            _isBonus = false;
        }

        public void Register(object roll)
        {
            _rollCount += 1;
            if (IsAtNewFrame())
            {
                FrameScore = 0;
            }

            var score = ((Roll) roll).Score;
            FrameScore += score;
            Score += score;

            if (_isBonus)
            {
                Score += score;
            }

            _isBonus = FrameScore == 10;

        }

        private bool IsAtNewFrame()
        {
            return (_rollCount % 2) == 1;
        }
    }
}