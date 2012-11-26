namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }

        private readonly BonusMultiplierQueue _bonusMultiplierQueue;

        public TenPinScorer()
        {
            Score = 0;
            _bonusMultiplierQueue = new BonusMultiplierQueue();
        }

        public void Register(IRoll roll)
        {
            var currentBonusMultiplier = _bonusMultiplierQueue.DequeueBonusMultiplier(roll);

            Score += currentBonusMultiplier * roll.PinsKnocked;

            _bonusMultiplierQueue.EnqueueBonusMultiplier(roll);
        }
    }
}