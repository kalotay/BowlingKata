namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }
        public int FrameScore { get; private set; }

        private int _bonusReach;

        public TenPinScorer()
        {
            Score = 0;
            FrameScore = 0;
            _bonusReach = 0;
        }

        public void Register(IRoll roll)
        {
            var atFirstRoll = roll is FirstRoll;

            if (atFirstRoll)
            {
                FrameScore = 0;
            }

            var score = roll.Score;
            FrameScore += score;
            Score += score;

            if (IsBonus())
            {
                Score += score;
                _bonusReach -= 1;
            }

            if (FrameScore == 10)
            {
                _bonusReach += 1;
                if (atFirstRoll)
                {
                    _bonusReach += 1;
                }
            }
        }

        private bool IsBonus()
        {
            return _bonusReach > 0;
        }
    }
}