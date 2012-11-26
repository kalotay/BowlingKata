namespace Bowling
{
    public class BonusMultiplierQueue : IBonusMultiplierQueue
    {
        private readonly int[] _bonuses;

        public BonusMultiplierQueue()
        {
            _bonuses = new[] {1, 1, 1};
        }

        public void Enqueue(IRoll roll)
        {
            switch (roll.Type)
            {
                case RollTypes.Strike:
                    _bonuses[2] += 1;
                    goto case RollTypes.Spare;
                case RollTypes.Spare:
                    _bonuses[1] += 1;
                    break;
                case RollTypes.Bonus:
                    _bonuses[0] -= 1;
                    break;
            }
        }

        public int Dequeue()
        {
            var currentBonusMultiplier = _bonuses[0];
            for (var i = 0; i < (_bonuses.Length - 1); i += 1)
            {
                _bonuses[i] = _bonuses[i + 1];
            }
            _bonuses[_bonuses.Length - 1] = 1;
            return currentBonusMultiplier;
        }
    }
}