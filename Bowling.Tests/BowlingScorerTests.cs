using System.Linq;
using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class BowlingScorerTests
    {
        private BowlingScorer _scorer;
        private readonly BowlingFilter _filter = new BowlingFilter();
        private readonly RollMapper _mapper = new RollMapper();

        [SetUp]
        public void SetUp()
        {
            _scorer = new BowlingScorer(new StatefulFrameFactory());
        }

        [Test]
        public void InitialScoreIsZero()
        {
            Assert.That(_scorer.Score, Is.EqualTo(0));
        }

        [Test]
        public void InitiallyIncomplete()
        {
            Assert.That(_scorer.IsComplete, Is.False);
        }

        [TestCase("1111", false)]
        [TestCase("xxxxxxxxxxxx", true)]
        [TestCase("11111111111111111111", true)]
        public void TestCompletion(string rolls, bool completion)
        {
            var filtered = _filter.Filter(rolls);
            foreach (var mapped in filtered.Select(roll => _mapper.Map(roll)))
            {
                _scorer.Register(mapped);
            }

            Assert.That(_scorer.IsComplete, Is.EqualTo(completion));
        }
    }
}