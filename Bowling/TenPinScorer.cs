namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public TenPinScorer()
        {
            Score = 0;
        }

        public int Score { get; private set; }
        public void Register(object roll)
        {
            Score += (int)roll;
        }
    }
}