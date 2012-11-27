using Bowling.DefaultImplementation;
using Bowling.Interface;
using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class BonusMultiplierTests
    {
        private BonusMultiplier _bonusMultiplier;

        [SetUp]
        public void CreateBonusMultiplier()
        {
            _bonusMultiplier = new BonusMultiplier();
        }

        [Test]
        public void InitialBonusMultiplierIsOne()
        {
            Assert.That(_bonusMultiplier.Current, Is.EqualTo(1));
        }

        [Test]
        public void RegisteringANormalRollLeavesTheMultiplierUnchanged()
        {
            _bonusMultiplier.Register(RollTypes.Normal);

            Assert.That(_bonusMultiplier.Current, Is.EqualTo(1));
        }

        [Test]
        public void RegisteringABonusRollDecrementsTheMultiplier()
        {
            _bonusMultiplier.Register(RollTypes.Bonus);

            Assert.That(_bonusMultiplier.Current, Is.EqualTo(0));
        }

        [Test]
        public void RegisteringASpareIncrementsTheNextMultiplier()
        {
            _bonusMultiplier.Register(RollTypes.Spare);
            var first = _bonusMultiplier.Current;
            _bonusMultiplier.Register(RollTypes.Normal);
            var second = _bonusMultiplier.Current;

            Assert.That(first, Is.EqualTo(1));
            Assert.That(second, Is.EqualTo(2));
        }

        [Test]
        public void RegisteringASpareIncrementsTheNextMultiplierAndTheFollowingOne()
        {
            _bonusMultiplier.Register(RollTypes.Strike);
            var first = _bonusMultiplier.Current;
            _bonusMultiplier.Register(RollTypes.Normal);
            var second = _bonusMultiplier.Current;
            _bonusMultiplier.Register(RollTypes.Normal);
            var third = _bonusMultiplier.Current;

            Assert.That(first, Is.EqualTo(1));
            Assert.That(second, Is.EqualTo(2));
            Assert.That(third, Is.EqualTo(2));
        }

        [Test]
        public void NormalStrikeSpareBonusSequenceHasMultipliers1122()
        {
            _bonusMultiplier.Register(RollTypes.Normal);
            var first = _bonusMultiplier.Current;
            _bonusMultiplier.Register(RollTypes.Strike);
            var second = _bonusMultiplier.Current;
            _bonusMultiplier.Register(RollTypes.Spare);
            var third = _bonusMultiplier.Current;
            _bonusMultiplier.Register(RollTypes.Bonus);
            var fourth = _bonusMultiplier.Current;

            Assert.That(first, Is.EqualTo(1));
            Assert.That(second, Is.EqualTo(1));
            Assert.That(third, Is.EqualTo(2));
            Assert.That(fourth, Is.EqualTo(2));
        }

    }
}