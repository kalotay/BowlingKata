namespace Bowling.Interface
{
    public interface IScorer
    {
        int Score { get; }
        void Register(IRoll roll);
    }
}