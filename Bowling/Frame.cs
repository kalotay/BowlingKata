using System;

namespace Bowling
{
    public class Frame: IScorer<int>
    {
        private int _score;
        private int _moveCount;

        public Frame()
        {
            _moveCount = 0;
            _score = 0;
        }

        public IComparable<int> Score
        {
            get { return _score; }
        }

        public void Register(int move)
        {
            _score += move;
            _moveCount += 1;
        }

        public bool IsComplete
        {
            get { return _moveCount >= 2; }
        }
    }
}