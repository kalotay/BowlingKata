namespace Bowling
{
    public class BonusMultiplierQueue
    {
        private int _nextBonusMultiplier;
        private int _nextNextBonusMultiplier;

        public BonusMultiplierQueue()
        {
            _nextBonusMultiplier = 1;
            _nextNextBonusMultiplier = 1;
        }

        public void EnqueueBonusMultiplier(IRoll roll)
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

        public int DequeueBonusMultiplier(IRoll roll)
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