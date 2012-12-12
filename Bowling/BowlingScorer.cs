using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingScorer
    {
        private readonly List<IScorer<int>> _frames;
        private readonly IStatefulFactory<IScorer<int>, int> _scorerFactory;

        public BowlingScorer(IStatefulFactory<IScorer<int>, int> scorerFactory)
        {
            _frames = new List<IScorer<int>>();
            _scorerFactory = scorerFactory;
        }

        public IComparable<int> Score
        {
            get { return _frames.Sum(f => (int) f.Score); }
        }

        public void Register(int move)
        {
            _scorerFactory.Register(move);
            if (_scorerFactory.CanGenerate)
            {
                var scorer = _scorerFactory.GetInstance();
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
    }
}