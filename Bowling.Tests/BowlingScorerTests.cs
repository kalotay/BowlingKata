using NUnit.Framework;
using System.Linq;

namespace Bowling.Tests
{
    [TestFixture]
    public class BowlingScorerTests
    {
        private IScorer<int> _scorer;
        private readonly BowlingFilter _filter = new BowlingFilter();
        private readonly RollMapper _mapper = new RollMapper();

        [SetUp]
        public void SetUp()
        {
            _scorer = new BowlingScorer();
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
        [TestCase("10,00,00,00,00,00,00,00,00,00", true, 1)]
        [TestCase("10,10,10,10,10,10,10,10,10,10", true, 10)]
        [TestCase("7/,81,32,31,33,9/,53,23,52,33", true, 83)]
        [TestCase("x,36,32,31,33,9/,53,23,52,33", true, 84)]
        [TestCase("x,36,32,31,33,9/,53,23,52,9/7", true, 95)]
        [TestCase("00,x,x,x,x,x,x,x,x,xxx", true, 270)]
        [TestCase("9/,9/,9/,9/,9/,9/,9/,9/,9/,90", true, 180)]
        [TestCase("7/,42,32,31,33,9/,53,23,52,33", true, 76)]
        [TestCase("x,7/,72,9/,x,x,x,23,6/,7/3", true, 168)]
        public void TestCases(string rolls, bool completion, int score)
        {
            var filtered = _filter.Filter(rolls);
            var scorer = filtered.Select(roll => _mapper.Map(roll))
                .Aggregate(_scorer, (current, roll) => current.Register(roll));

            Assert.That(scorer.IsComplete, Is.EqualTo(completion));
            Assert.That(scorer.Score, Is.EqualTo(score));
        }
    }
}
