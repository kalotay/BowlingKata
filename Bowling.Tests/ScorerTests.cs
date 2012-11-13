using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class ScorerTests
    {
        private IScorer _scorer;

        [SetUp]
        public void CreateScorer()
        {
            _scorer = new TenPinScorer();
        }

        [Test]
        public void OneGutterBallScoresZero()
        {
            _scorer.Register(new FirstRoll(0));

            Assert.That(_scorer.Score, Is.EqualTo(0));
        }

        [Test]
        public void OnePinKnockedDownScoresOne()
        {
            _scorer.Register(new FirstRoll(1));

            Assert.That(_scorer.Score, Is.EqualTo(1));
        }

        [Test]
        public void OnePinFollowedByOnePinScoresTwo()
        {
            _scorer.Register(new FirstRoll(1));
            _scorer.Register(new SecondRoll(1));

            Assert.That(_scorer.Score, Is.EqualTo(2));
        }

        [Test]
        public void SpareFollowedByFourPinsScoresEighteen()
        {
            _scorer.Register(new FirstRoll(7));
            _scorer.Register(new SecondRoll(3));
            _scorer.Register(new FirstRoll(4));

            Assert.That(_scorer.Score, Is.EqualTo(18));
        }

        [Test]
        public void GutterFollowedByTwoFivesFollowedByOneScoresEleven()
        {
            _scorer.Register(new FirstRoll(0));
            _scorer.Register(new SecondRoll(5));
            _scorer.Register(new FirstRoll(5));
            _scorer.Register(new SecondRoll(1));

            Assert.That(_scorer.Score, Is.EqualTo(11));
        }

        [Test]
        public void StrikeFollowedByThreeFollowedBySixScoresTwentyEight()
        {
            _scorer.Register(new FirstRoll(10));
            _scorer.Register(new FirstRoll(3));
            _scorer.Register(new SecondRoll(6));

            Assert.That(_scorer.Score, Is.EqualTo(28));
        }
    }
}