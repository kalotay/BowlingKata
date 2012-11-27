using Bowling.Interface;

namespace Bowling.DefaultImplementation
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }

        private readonly IBonusMultiplier _bonusMultiplier;

        public TenPinScorer()
        {
            Score = 0;
            _bonusMultiplier = new BonusMultiplier();
        }

        public void Register(IRoll roll)
        {
            _bonusMultiplier.Register(roll);
            var currentBonusMultiplier = _bonusMultiplier.Current;
            Score += currentBonusMultiplier * roll.PinsKnocked;

        }
    }
}