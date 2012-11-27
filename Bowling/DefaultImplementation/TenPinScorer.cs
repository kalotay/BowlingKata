using Bowling.Interface;

namespace Bowling.DefaultImplementation
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }

        private readonly IBonusMultiplier _bonusMultiplier;

        public TenPinScorer(IBonusMultiplier bonusMultiplier)
        {
            Score = 0;
            _bonusMultiplier = bonusMultiplier;
        }

        public TenPinScorer(): this(new BonusMultiplier()) {}

        public void Register(IRoll roll)
        {
            _bonusMultiplier.Register(roll.Type);
            var currentBonusMultiplier = _bonusMultiplier.Current;
            Score += currentBonusMultiplier * roll.PinsKnocked;
        }
    }
}