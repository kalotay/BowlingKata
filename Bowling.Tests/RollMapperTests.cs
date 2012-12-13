using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class RollMapperTests
    {
        private RollMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mapper = new RollMapper();
        }

        [TestCase('0', 0)]
        [TestCase('1', 1)]
        [TestCase('2', 2)]
        [TestCase('3', 3)]
        [TestCase('4', 4)]
        [TestCase('5', 5)]
        [TestCase('6', 6)]
        [TestCase('7', 7)]
        [TestCase('8', 8)]
        [TestCase('9', 9)]
        public void MapsDigitToEquivalentInt(char digit, int expected)
        {
            var actual = _mapper.Map(digit);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}