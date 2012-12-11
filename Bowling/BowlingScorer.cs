using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingScorer: IScorer<int>
    {
        private readonly List<IScorer<int>> _frames;
        private int _sinceLastGen = 0;
        private int _frameCount = 0;
        public bool IsFrameToBeGenerated { get; private set; }

        public BowlingScorer()
        {
            _frames = new List<IScorer<int>>();
        }

        public IComparable<int> Score
        {
            get { return _frames.Sum(f => (int) f.Score); }
        }

        public void Register(int move)
        {
            Register1(move);
            if (IsFrameToBeGenerated)
            {
                var scorer = GetInstance();
                _frames.Add(scorer);
            }

            if (IsComplete) throw new CompletedException();

            foreach (var frame in _frames.Where(f => !f.IsComplete))
            {
                frame.Register(move);
            }
        }

        private IScorer<int> GetInstance()
        {
            _sinceLastGen = 0;
            _frameCount += 1;
            return new Frame();
        }

        public bool IsComplete
        {
            get { return _frames.Count >= 10 && _frames.All(f => f.IsComplete); }
        }

        private void Register1(int roll)
        {
            _sinceLastGen += 1;
            IsFrameToBeGenerated = (_frameCount == 0) || ((_frameCount < 10) && (roll == 10 || (_sinceLastGen == 2)));
        }
    }
}