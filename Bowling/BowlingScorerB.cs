using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingScorerB: IScorer<int>
    {
        private readonly IReadOnlyCollection<IScorer<int>> _frames;

        public BowlingScorerB()
        {
            _frames = new List<IScorer<int>>();
        }

        internal BowlingScorerB(IReadOnlyCollection<IScorer<int>> frames)
        {
            _frames = frames;
        }

        public int Score
        {
            get { return _frames.Sum(f => f.Score); }
        }

        public IScorer<int> Register(int move)
        {
            var newFrame = Enumerable.Repeat(new Frame(), 1);
            var updatedFrames = _frames.Concat(newFrame).Select(f => f.Register(move));

            return new BowlingScorerA(updatedFrames.ToList());
        }

        public bool IsComplete
        {
            get { return false; }
        }
    }
}