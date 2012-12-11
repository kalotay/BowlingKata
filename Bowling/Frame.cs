using System;

namespace Bowling
{
    public class Frame: IScorer<int>
    {
        private int _score;

        public Frame()
        {
            _score = 0;
        }

        public IComparable<int> Score
        {
            get { return _score; }
        }

        public void Register(int move)
        {
            _score += move;
        }

        public bool IsComplete
        {
            get { return default(bool); }
        }
    }
}