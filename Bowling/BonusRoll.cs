namespace Bowling
{
    public struct BonusRoll : IRoll
    {
        public int Score { get; private set; }

        public BonusRoll(int score): this()
        {
            Score = score;
        }
    }
}