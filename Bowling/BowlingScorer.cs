using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingScorer: IScorer<int>
    {
        private readonly List<IScorer<int>> _frames;
        private readonly StatefulFrameFactory _statefulFrameFactory;

        public BowlingScorer()
        {
            _frames = new List<IScorer<int>>();
            _statefulFrameFactory = new StatefulFrameFactory();
        }

        public IComparable<int> Score
        {
            get { return _frames.Sum(f => (int) f.Score); }
        }

        public void Register(int move)
        {
            StatefulFrameFactory.Register(move);
            if (StatefulFrameFactory.CanGenerate)
            {
                var scorer = StatefulFrameFactory.GetInstance();
                _frames.Add(scorer);
            }

            if (IsComplete) throw new CompletedException();

            foreach (var frame in _frames.Where(f => !f.IsComplete))
            {
                frame.Register(move);
            }
        }

        public bool IsComplete
        {
            get { return _frames.Count >= 10 && _frames.All(f => f.IsComplete); }
        }

        public StatefulFrameFactory StatefulFrameFactory
        {
            get { return _statefulFrameFactory; }
        }
    }
}