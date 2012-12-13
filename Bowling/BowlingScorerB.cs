using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingScorerB: IScorer<int>
    {
        private readonly IReadOnlyCollection<IScorer<int>> _frames;

        internal BowlingScorerB(IReadOnlyCollection<IScorer<int>> frames)
        {
            _frames = frames;
        }

        public int Score
        {
            get { return _frames.Sum(scorer => scorer.Score); }
        }

        public IScorer<int> Register(int move)
        {
            var newFrame = Enumerable.Repeat(new Frame(), 1);
            var updatedFrames = _frames.Select(scorer => scorer.Register(move)).Concat(newFrame);

            return new BowlingScorerA(updatedFrames.ToList());
        }

        public bool IsComplete
        {
            get { return false; }
        }
    }
}