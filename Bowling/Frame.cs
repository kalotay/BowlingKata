using System;

namespace Bowling
{
    public class Frame: IScorer<int>
    {
        private readonly int _score;
        private readonly int _moveCount;

        public Frame()
        {
            _moveCount = 0;
            _score = 0;
        }

        private Frame(int score, int moveCount)
        {
            _score = score;
            _moveCount = moveCount;
        }

        public int Score
        {
            get { return _score; }
        }

        public IScorer<int> Register(int move)
        {
            var newScore = _score + move;
            if ((_moveCount == 2) || ((_moveCount == 1) && (newScore < 10)))
            {
                return new CompletedScorer<int>(newScore);
            }
            return new Frame(newScore, _moveCount + 1);
        }

        public bool IsComplete
        {
            get { return false; }
        }
    }
}