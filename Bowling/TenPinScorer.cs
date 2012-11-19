namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }
        public int FrameScore { get; private set; }

        private int _nextBonusMultiplier;
        private int _nextNextBonusMultiplier;

        public TenPinScorer()
        {
            Score = 0;
            FrameScore = 0;
            _nextBonusMultiplier = 1;
            _nextNextBonusMultiplier = 1;
        }

        public void Register(Roll roll)
        {
            var currentBonusMultiplier = PopBonusMultiplier();

            if (roll.RollNumber > 2)
            {
                currentBonusMultiplier -= 1;
            }

            if (roll.RollNumber == 1)
            {
                FrameScore = 0;
            }

            var score = roll.PinsKnocked;

            FrameScore += score;
            Score += currentBonusMultiplier * score;

            PushBonusMultiplier(roll);
        }

        private void PushBonusMultiplier(Roll roll)
        {
            if (FrameScore == 10)
            {
                _nextBonusMultiplier += 1;
                if (roll.RollNumber == 1)
                {
                    _nextNextBonusMultiplier += 1;
                }
            }
        }

        private int PopBonusMultiplier()
        {
            var currentBonusMultiplier = _nextBonusMultiplier;
            _nextBonusMultiplier = _nextNextBonusMultiplier;
            _nextNextBonusMultiplier = 1;
            return currentBonusMultiplier;
        }
    }
}