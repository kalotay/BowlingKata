using Bowling.Interface;

namespace Bowling.DefaultImplementation
{
    public class BonusMultiplier : IBonusMultiplier
    {
        private readonly int[] _bonuses;

        public BonusMultiplier()
        {
            _bonuses = new[] {1, 1, 1};
        }

        public void Register(RollTypes rollType)
        {
            ShiftBonuses();
            switch (rollType)
            {
                case RollTypes.Strike:
                    _bonuses[2] += 1;
                    _bonuses[1] += 1;
                    break;
                case RollTypes.Spare:
                    _bonuses[1] += 1;
                    break;
                case RollTypes.Bonus:
                    _bonuses[0] -= 1;
                    break;
            }
        }

        public int Current { get { return _bonuses[0]; } }

        private void ShiftBonuses()
        {
            var lastIndex = _bonuses.Length - 1;
            for (var i = 0; i < lastIndex; i += 1)
            {
                _bonuses[i] = _bonuses[i + 1];
            }
            _bonuses[lastIndex] = 1;
        }
    }
}