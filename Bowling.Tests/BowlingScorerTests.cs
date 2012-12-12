using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace Bowling.Tests
{
    [TestFixture]
    public class BowlingScorerTests
    {
        private IScorer<int> _scorer;

        [SetUp]
        public void SetUp()
        {
            _scorer = new BowlingScorerB();
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
            var scorer = rolls.Aggregate(_scorer, (current, roll) => current.Register(roll));
            Assert.That(scorer.IsComplete, Is.EqualTo(completion));
        }
    }
}