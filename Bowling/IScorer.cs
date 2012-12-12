namespace Bowling
{
    public interface IScorer<in T>
    {
        int Score { get; }
        IScorer<T> Register(T move);
        bool IsComplete { get; }
    }
}