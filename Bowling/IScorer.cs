namespace Bowling
{
    public interface IScorer
    {
        int Score { get; }
        void Register(object roll);
    }
}