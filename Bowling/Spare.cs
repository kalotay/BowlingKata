namespace Bowling
{
    public struct Spare: IRoll
    {
        public int PinsKnocked { get; set; }
        public RollTypes Type { get { return RollTypes.Spare;} }
    }
}