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
            _scorer.Register(new NormalRoll { PinsKnocked = 0 });

            Assert.That(_scorer.Score, Is.EqualTo(0));
        }

        [Test]
        public void OnePinKnockedDownScoresOne()
        {
            _scorer.Register(new NormalRoll { PinsKnocked = 1});

            Assert.That(_scorer.Score, Is.EqualTo(1));
        }

        [Test]
        public void OnePinFollowedByOnePinScoresTwo()
        {
            _scorer.Register(new NormalRoll { PinsKnocked =1 });
            _scorer.Register(new NormalRoll { PinsKnocked = 1});

            Assert.That(_scorer.Score, Is.EqualTo(2));
        }

        [Test]
        public void SpareFollowedByFourPinsScoresEighteen()
        {
            _scorer.Register(new NormalRoll { PinsKnocked =7});
            _scorer.Register(new Spare {PinsKnocked = 3});
            _scorer.Register(new NormalRoll { PinsKnocked =4});

            Assert.That(_scorer.Score, Is.EqualTo(18));
        }

        [Test]
        public void GutterFollowedByTwoFivesFollowedByOneScoresEleven()
        {
            _scorer.Register(new NormalRoll { PinsKnocked =0});
            _scorer.Register(new NormalRoll { PinsKnocked = 5});
            _scorer.Register(new NormalRoll { PinsKnocked =5});
            _scorer.Register(new NormalRoll { PinsKnocked = 1});

            Assert.That(_scorer.Score, Is.EqualTo(11));
        }

        [Test]
        public void StrikeFollowedByThreeFollowedBySixScoresTwentyEight()
        {
            _scorer.Register(new Strike());
            _scorer.Register(new NormalRoll { PinsKnocked =3});
            _scorer.Register(new NormalRoll { PinsKnocked = 6 });

            Assert.That(_scorer.Score, Is.EqualTo(28));
        }

        [Test]
        public void PerfectGameScoresThreehundred()
        {
            for (var i = 0; i < 10; i++)
            {
                _scorer.Register(new Strike());
            }

            _scorer.Register(new BonusRoll {PinsKnocked = 10});
            _scorer.Register(new BonusRoll {PinsKnocked = 10});

            Assert.That(_scorer.Score, Is.EqualTo(300));
        }
    }
}