using System;

namespace Bowling
{
    public class Frame: IScorer<int>
    {
        public IComparable<int> Score
        {
            get { return default(int); }
        }

        public void Register(int move)
        {
        }

        public bool IsComplete
        {
            get { return default(bool); }
        }
    }
}