namespace Bowling
{
    public struct FirstRoll: IRoll
    {
        public int Score { get; private set; }

        public FirstRoll(int score): this()
        {
            Score = score;
        }
    }
}