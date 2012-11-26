namespace Bowling
{
    public struct NormalRoll: IRoll
    {
        public int PinsKnocked { get; set; }
        public RollTypes Type { get {return RollTypes.Normal;} }
    }
}