namespace Bowling.Interface
{
    public interface IBonusMultiplier
    {
        void Register(IRoll roll);
        int Current { get; }
    }
}