namespace Bowling.Interface
{
    public interface IRoll
    {
        int PinsKnocked { get; }
        RollTypes Type { get; }
    }
}