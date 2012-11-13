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
            _scorer.Register(0);

            Assert.That(_scorer.Score, Is.EqualTo(0));
        }

        [Test]
        public void OnePinKnockedDownScoresOne()
        {
            _scorer.Register(1);

            Assert.That(_scorer.Score, Is.EqualTo(1));
        }

        [Test]
        public void OnePinFollowedByOnePinScoresTwo()
        {
            _scorer.Register(1);
            _scorer.Register(1);

            Assert.That(_scorer.Score, Is.EqualTo(2));
        }

        [Test]
        public void SpareFollowedByFourPinsScoresEighteen()
        {
            _scorer.Register(7);
            _scorer.Register(3);
            _scorer.Register(4);

            Assert.That(_scorer.Score, Is.EqualTo(18));
        }

        [Test]
        public void GutterFollowedByTwoFivesFollowedByOneScoresEleven()
        {
            _scorer.Register(0);
            _scorer.Register(5);
            _scorer.Register(5);
            _scorer.Register(1);

            Assert.That(_scorer.Score, Is.EqualTo(11));
        }
    }
}