using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingScorerPrime: IScorer<int>
    {
        private readonly IReadOnlyCollection<IScorer<int>> _frames;

        internal BowlingScorerPrime(IReadOnlyCollection<IScorer<int>> frames)
        {
            _frames = frames;
        }

        public int Score
        {
            get { return _frames.Sum(scorer => scorer.Score); }
        }

        public IScorer<int> Register(int move)
        {
            var updatedFrames = _frames.Select(scorer => scorer.Register(move));
            var newFrame = Enumerable.Repeat(new Frame(), 1);

            return new BowlingScorer(updatedFrames.Concat(newFrame).ToList());
        }

        public bool IsComplete
        {
            get { return false; }
        }
    }
}