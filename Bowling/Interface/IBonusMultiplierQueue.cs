namespace Bowling.Interface
{
    public interface IBonusMultiplierQueue
    {
        void Register(IRoll roll);
        int Current { get; }
    }
}