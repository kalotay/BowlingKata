using Bowling.Interface;

namespace Bowling.DefaultImplementation
{
    public struct Strike: IRoll
    {
        public int PinsKnocked { get { return 10; } }
        public RollTypes Type { get {return RollTypes.Strike;} }
    }
}