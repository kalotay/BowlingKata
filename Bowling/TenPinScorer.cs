namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }

        private int _nextBonusMultiplier;
        private int _nextNextBonusMultiplier;

        public TenPinScorer()
        {
            Score = 0;
            _nextBonusMultiplier = 1;
            _nextNextBonusMultiplier = 1;
        }

        public void Register(IRoll roll)
        {
            var currentBonusMultiplier = DequeueBonusMultiplier(roll);

            Score += currentBonusMultiplier * roll.PinsKnocked;

            EnqueueBonusMultiplier(roll);
        }

        private void EnqueueBonusMultiplier(IRoll roll)
        {
            switch (roll.Type)
            {
                case RollTypes.Strike:
                    _nextNextBonusMultiplier += 1;
                    goto case RollTypes.Spare;
                case RollTypes.Spare:
                    _nextBonusMultiplier += 1;
                    break;
            }
        }

        private int DequeueBonusMultiplier(IRoll roll)
        {
            var currentBonusMultiplier = _nextBonusMultiplier;
            if (roll.Type == RollTypes.Bonus)
            {
                currentBonusMultiplier -= 1;
            }
            _nextBonusMultiplier = _nextNextBonusMultiplier;
            _nextNextBonusMultiplier = 1;
            return currentBonusMultiplier;
        }
    }
}