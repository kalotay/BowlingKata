namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        private int _frameScore;
        private int _rollCount;
        private bool _isBonus;
        public int Score { get; private set; }

        public TenPinScorer()
        {
            Score = 0;
            _frameScore = 0;
            _rollCount = 0;
            _isBonus = false;
        }

        public void Register(object roll)
        {
            _rollCount += 1;
            if (IsAtNewFrame())
            {
                _frameScore = 0;
            }

            var score = (int) roll;
            _frameScore += score;
            Score += score;

            if (_isBonus)
            {
                Score += score;
            }

            _isBonus = _frameScore == 10;

        }

        private bool IsAtNewFrame()
        {
            return (_rollCount % 2) == 1;
        }
    }
}