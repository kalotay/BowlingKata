namespace Bowling
{
    public interface IRoll
    {
        int PinsKnocked { get; }
        RollTypes Type { get; }
    }
}