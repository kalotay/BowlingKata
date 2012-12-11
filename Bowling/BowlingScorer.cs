using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingScorer: IScorer<int>
    {
        private readonly List<IScorer<int>> _frames;
        private int _sinceLastGen;
        private int _frameCount;

        public BowlingScorer()
        {
            _frames = new List<IScorer<int>>();
            _sinceLastGen = 0;
            _frameCount = 0;
        }

        public IComparable<int> Score
        {
            get { return _frames.Sum(f => (int) f.Score); }
        }

        public void Register(int move)
        {
            if (IsFrameToBeGenerated(move))
            {
                var scorer = GetInstance();
                _frames.Add(scorer);
                _frameCount += 1;
            }

            if (IsComplete) throw new CompletedException();

            foreach (var frame in _frames.Where(f => !f.IsComplete))
            {
                frame.Register(move);
            }

            _sinceLastGen += 1;
        }

        private IScorer<int> GetInstance()
        {
            _sinceLastGen = 0;
            return new Frame();
        }

        public bool IsComplete
        {
            get { return _frames.Count >= 10 && _frames.All(f => f.IsComplete); }
        }

        private bool IsFrameToBeGenerated(int roll)
        {
            var isFrameToBeGenerated = (_frameCount < 10) && (roll == 10 || (_sinceLastGen%2) == 0);

            return isFrameToBeGenerated;
        }
    }
}