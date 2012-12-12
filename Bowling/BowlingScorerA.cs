using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingScorerA: IScorer<int>
    {
        private readonly IReadOnlyCollection<IScorer<int>> _frames;

        internal BowlingScorerA(IReadOnlyCollection<IScorer<int>> frames)
        {
            _frames = frames;
        }

        public int Score
        {
            get { return _frames.Sum(f => f.Score); }
        }

        public IScorer<int> Register(int move)
        {
            var updatedFrames = _frames.Select(f => f.Register(move)).ToList();

            if (updatedFrames.Count(f => f.IsComplete) == 10)
            {
                return new CompletedScorer<int>(updatedFrames.Sum(f => Score));
            }

            if (_frames.Count == 10)
            {
                return new BowlingScorerA(updatedFrames);
            }

            if (move == 10)
            {
                var newFrame = Enumerable.Repeat(new Frame(), 1).Select(f => f.Register(move));
                return new BowlingScorerA(updatedFrames.Concat(newFrame).ToList());
            }

            return new BowlingScorerB(updatedFrames);
        }

        public bool IsComplete
        {
            get { return false; }
        }
    }
}