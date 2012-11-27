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
    }
}