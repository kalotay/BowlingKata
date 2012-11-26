namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }

        private readonly IBonusMultiplierQueue _bonusMultiplierQueue;

        public TenPinScorer()
        {
            Score = 0;
            _bonusMultiplierQueue = new BonusMultiplierQueue();
        }

        public void Register(IRoll roll)
        {
            var currentBonusMultiplier = _bonusMultiplierQueue.Dequeue(roll);

            Score += currentBonusMultiplier * roll.PinsKnocked;

            _bonusMultiplierQueue.Enqueue(roll);
        }
    }
}