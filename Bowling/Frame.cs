using System;

namespace Bowling
{
    public class Frame: IScorer<int>
    {
        public Frame()
        {
            Score = 0;
        }

        public IComparable<int> Score { get; private set; }

        public void Register(int move)
        {
            Score = move;
        }

        public bool IsComplete
        {
            get { return default(bool); }
        }
    }
}