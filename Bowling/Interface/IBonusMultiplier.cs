namespace Bowling.Interface
{
    public interface IBonusMultiplier
    {
        void Register(RollTypes rollType);
        int Current { get; }
    }
}