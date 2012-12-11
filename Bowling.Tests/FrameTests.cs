using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class FrameTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUp()
        {
            _frame = new Frame();
        }

        [Test]
        public void InitialScoreIsZero()
        {
            Assert.That(_frame.Score, Is.EqualTo(0));
        }

        [Test]
        public void InitallyIncomplete()
        {
            Assert.That(_frame.IsComplete, Is.False);
        }
    }
}