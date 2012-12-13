using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingScorer: IScorer<int>
    {
        private readonly IReadOnlyCollection<IScorer<int>> _frames;

        public BowlingScorer()
        {
            _frames = new List<IScorer<int>> { new Frame() };
        }

        internal BowlingScorer(IReadOnlyCollection<IScorer<int>> frames)
        {
            _frames = frames;
        }

        public int Score
        {
            get { return _frames.Sum(scorer => scorer.Score); }
        }

        public IScorer<int> Register(int move)
        {
            var updatedFrames = _frames.Select(scorer => scorer.Register(move)).ToList();

            if (updatedFrames.Count(f => f.IsComplete) == 10)
            {
                return new CompletedScorer<int>(updatedFrames.Sum(scorer => scorer.Score));
            }

            if (_frames.Count == 10)
            {
                return new BowlingScorer(updatedFrames);
            }

            if (move == 10)
            {
                var newFrame = Enumerable.Repeat(new Frame(), 1);
                return new BowlingScorer(updatedFrames.Concat(newFrame).ToList());
            }

            return new BowlingScorerPrime(updatedFrames);
        }

        public bool IsComplete
        {
            get { return false; }
        }
    }
}