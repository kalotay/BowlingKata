namespace Bowling
{
    public struct SecondRoll: IRoll
    {
        public int Score { get; private set; }

        public SecondRoll(int score): this()
        {
            Score = score;
        }

    }
}