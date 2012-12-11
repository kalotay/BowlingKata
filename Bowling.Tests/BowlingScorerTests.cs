using NUnit.Framework;

namespace Bowling.Tests
{
    public class BowlingScorerTests
    {
        private BowlingScorer _scorer;

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

        [TestCase(new[] { 1, 1, 1, 1 }, false)]
        [TestCase(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}, true)]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, true)]
        public void TestCompletion(int[] rolls, bool completion)
        {
            foreach (var roll in rolls)
            {
                _scorer.Register(roll);
            }

            Assert.That(_scorer.IsComplete, Is.EqualTo(completion));
        }
    }
}