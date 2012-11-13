namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }
        public int FrameScore { get; private set; }

        private int _bonusReach;
        private int _nextBonusMultiplier;
        private int _nextNextBonusMultiplier;

        public TenPinScorer()
        {
            Score = 0;
            FrameScore = 0;
            _bonusReach = 0;
            _nextBonusMultiplier = 1;
            _nextNextBonusMultiplier = 1;
        }

        public void Register(IRoll roll)
        {
            var currentBonusMultiplier = _nextBonusMultiplier;
            _nextBonusMultiplier = _nextNextBonusMultiplier;
            _nextNextBonusMultiplier = 1;

            if (roll is BonusRoll)
            {
                currentBonusMultiplier -= 1;
            }

            var atFirstRoll = roll is FirstRoll;

            if (atFirstRoll)
            {
                FrameScore = 0;
            }

            var score = roll.Score;

            FrameScore += score;
            Score += currentBonusMultiplier * score;

            if (FrameScore == 10)
            {
                _nextBonusMultiplier += 1;
                if (atFirstRoll)
                {
                    _nextNextBonusMultiplier += 1;
                }
            }
        }

        private bool IsBonus()
        {
            return _bonusReach > 0;
        }
    }
}