namespace Bowling
{
    public class TenPinScorer: IScorer
    {
        public TenPinScorer()
        {
            Score = default(int);
        }

        public int Score { get; private set; }
        public void Register(object roll)
        {
            Score = (int)roll;
        }
    }
}