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
        private IBonusMultiplier _bonusMultiplier;
        private TenPinScorer _scorer;

        [SetUp]
        public void Setup()
        {
            _bonusMultiplier = Substitute.For<IBonusMultiplier>();
            _scorer = new TenPinScorer(_bonusMultiplier);
        }

        [Test]
        public void InitialScoreIs0()
        {
            Assert.That(_scorer.Score, Is.EqualTo(0));
        }

        
        [Test]
        public void BonusMultiplierIsCalledCorrectNumberOfTimes()
        {
            _scorer.Register(new Strike());
            _scorer.Register(new Spare());
            _scorer.Register(new NormalRoll());

            var rollTypes = new[] {RollTypes.Strike, RollTypes.Spare, RollTypes.Normal};

            var _ = _bonusMultiplier.Received(3).Current;
            _bonusMultiplier.Received(3).Register(Arg.Is<RollTypes>(t => rollTypes.Any(t_ => t_ == t)));
            _bonusMultiplier.DidNotReceive().Register(RollTypes.Bonus);
        }

        [Test]
        public void ScoreIsSumOfPinsKnockedTimesMultiplier()
        {
            _bonusMultiplier.Current.Returns(1, 3, 2, 0);

            _scorer.Register(new Strike());
            var first = _scorer.Score;

            _scorer.Register(new Strike());
            var second = _scorer.Score;

            _scorer.Register(new Strike());
            var third = _scorer.Score;

            _scorer.Register(new Strike());
            var fourth = _scorer.Score;

            Assert.That(first, Is.EqualTo(10));
            Assert.That(second, Is.EqualTo(40));
            Assert.That(third, Is.EqualTo(60));
            Assert.That(fourth, Is.EqualTo(60));
        }
    }
}