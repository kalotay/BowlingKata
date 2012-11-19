namespace Bowling
{

    public class Roll
    {
        public readonly int PinsKnocked;
        public readonly int RollNumber;

        private Roll(int pinsKnocked, int rollNumber)
        {
            PinsKnocked = pinsKnocked;
            RollNumber = rollNumber;
        }

        public static Roll FirstRoll(int pinsKnocked)
        {
            return new Roll(pinsKnocked, 1);
        }

        public static Roll SecondRoll(int pinsKnocked)
        {
            return new Roll(pinsKnocked, 2);
        }

        public static Roll BonusRoll(int pinsKnocked)
        {
            return new Roll(pinsKnocked, 3);
        }

        public static Roll Strike()
        {
            return new Roll(10, 1);
        }
    }
}