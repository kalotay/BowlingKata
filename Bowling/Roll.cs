namespace Bowling
{
    public class Roll
    {
        public int Score { get; private set; }

        public Roll(int score)
        {
            Score = score;
        }
    }
}