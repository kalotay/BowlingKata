using System;
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

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void RegisteringOneRollYieldsScoreEqualToRoll(int actualExpected)
        {
            _frame.Register(actualExpected);

            Assert.That(_frame.Score, Is.EqualTo(actualExpected));
        }

        [Test]
        public void IsIncompleteAfterOneRoll()
        {
            _frame.Register(0);

            Assert.That(_frame.IsComplete, Is.False);
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 1, 1)]
        [TestCase(5, 5, 10)]
        [TestCase(10, 0, 10)]
        [TestCase(0, 10, 10)]
        public void RegisteringTwoRollsYieldsScoreEqualToSum(int first, int second, int expected)
        {
            _frame.Register(first);
            _frame.Register(second);

            Assert.That(_frame.Score, Is.EqualTo(expected));
        }

        [Test]
        public void RegisteringTwoRollsWithScoreLessThanTenYieldsCompletedFrame()
        {
            _frame.Register(1);
            _frame.Register(2);

            Assert.That(_frame.IsComplete, Is.True);
        }

        [TestCase(5, 5, 0, 10)]
        [TestCase(10, 0, 1, 11)]
        [TestCase(0, 10, 5, 15)]
        public void RegisteringThreeRollsYieldsScoreEqualToSum(int first, int second, int third, int expected)
        {
            _frame.Register(first);
            _frame.Register(second);
            _frame.Register(third);

            Assert.That(_frame.Score, Is.EqualTo(expected));
        }

        [Test]
        public void RegisteringTwoRollsWithScoreGreaterOrEqualtToTenOnFirstTwoYieldsIncompletedFrame()
        {
            _frame.Register(5);
            _frame.Register(5);

            Assert.That(_frame.IsComplete, Is.False);
        }

        [Test]
        public void RegisteringThreeRollsWithScoreGreaterOrEqualtToTenOnFirstTwoYieldsCompletedFrame()
        {
            _frame.Register(5);
            _frame.Register(5);
            _frame.Register(5);

            Assert.That(_frame.IsComplete, Is.True);
        }

        [Test]
        public void ThrowsCompletedExceptionIfRegisteringAfterCompletion()
        {
            _frame.Register(5);
            _frame.Register(0);

            Assert.Throws<CompletedException>(() => _frame.Register(1));
        }
    }
}