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

        [TestCase("1111", false, 4)]
        [TestCase("xxxxxxxxxxxx", true, 300)]
        [TestCase("11111111111111111111", true, 20)]
        [TestCase("00,00,00,00,00,00,00,00,00,00", true, 0)]
        [TestCase("10,00,00,00,00,00,00,00,00,00", true ,1)]
        public void TestCases(string rolls, bool completion, int score)
        {
            var filtered = _filter.Filter(rolls);
            foreach (var mapped in filtered.Select(roll => _mapper.Map(roll)))
            {
                _scorer.Register(mapped);
            }

            Assert.That(_scorer.IsComplete, Is.EqualTo(completion));
            Assert.That(_scorer.Score, Is.EqualTo(score));
        }
    }
}