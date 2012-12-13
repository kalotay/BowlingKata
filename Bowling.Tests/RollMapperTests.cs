using System;
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

        [Test]
        public void MapsXToTen()
        {
            var actual = _mapper.Map('x');

            Assert.That(actual, Is.EqualTo(10));
        }

        [TestCase('0')]
        [TestCase('1')]
        [TestCase('2')]
        [TestCase('3')]
        [TestCase('4')]
        [TestCase('5')]
        [TestCase('6')]
        [TestCase('7')]
        [TestCase('8')]
        [TestCase('9')]
        public void MapSlashToTenMinusPreviousRoll(char previous)
        {
            var previousInt = _mapper.Map(previous);
            var actual = _mapper.Map('/');

            Assert.That(actual, Is.EqualTo(10 - previousInt));
        }

        [Test]
        public void ThrowsExceptionOnInvalidChar()
        {
            var exception = Assert.Throws<ArgumentException>(() => _mapper.Map('a'));
            Assert.That(exception.Message, Is.EqualTo("'a' is not a valid roll"));
        }
    }
}