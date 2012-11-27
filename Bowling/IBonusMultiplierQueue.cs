namespace Bowling
{
    public interface IBonusMultiplierQueue
    {
        void Register(IRoll roll);
        int Current { get; }
    }
}