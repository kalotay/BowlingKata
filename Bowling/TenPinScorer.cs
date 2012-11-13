namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public int Score { get; private set; }

        public TenPinScorer()
        {
            Score = 0;
        }

        public void Register(object roll)
        {
            Score += (int)roll;
        }
    }
}