using Bowling.Interface;

namespace Bowling.DefaultImplementation
{
    public struct BonusRoll : IRoll
    {
        public int PinsKnocked { get; set; }
        public RollTypes Type { get {return RollTypes.Bonus;}}
    }
}