using Bowling.DefaultImplementation;
using Bowling.Interface;
using NSubstitute;
using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class ScorerTests
    {
        [Test]
        public void InitialScoreIs0()
        {
            var multiplier = Substitute.For<IBonusMultiplier>();
            var scorer = new TenPinScorer(multiplier);

            Assert.That(scorer.Score, Is.EqualTo(0));
        }
    }
}