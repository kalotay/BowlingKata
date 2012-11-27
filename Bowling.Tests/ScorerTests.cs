using Bowling.DefaultImplementation;
using Bowling.Interface;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void BonusMultiplierIsCalledCorrectNumberOfTimes()
        {
            var multiplier = Substitute.For<IBonusMultiplier>();
            var scorer = new TenPinScorer(multiplier);

            scorer.Register(new Strike());
            scorer.Register(new Spare());
            scorer.Register(new NormalRoll());
            var rollTypes = new[] {RollTypes.Strike, RollTypes.Spare, RollTypes.Normal};

            var unused = multiplier.Received(3).Current;
            multiplier.Received(3).Register(Arg.Is<RollTypes>(t => rollTypes.Any(t_ => t_ == t)));
            multiplier.DidNotReceive().Register(RollTypes.Bonus);
        }
    }
}