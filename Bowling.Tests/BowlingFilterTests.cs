using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class BowlingFilterTests
    {
        private BowlingFilter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new BowlingFilter();
        }

        [TestCase("", "")]
        [TestCase("1234567890xX/", "1234567890xX/")]
        [TestCase("1,2.3l4;5a6d7h8a9h0fxaX/", "1234567890xX/")]
        public void RemovesUnusedChars(string input, string expected)
        {
            var actual = _filter.Filter(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}