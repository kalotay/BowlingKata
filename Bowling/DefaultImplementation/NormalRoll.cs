using Bowling.Interface;

namespace Bowling.DefaultImplementation
{
    public struct NormalRoll: IRoll
    {
        public int PinsKnocked { get; set; }
        public RollTypes Type { get {return RollTypes.Normal;} }
    }
}