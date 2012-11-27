using System.Linq;
using Bowling.Interface;
using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class PinsKnockedDownMapperTests
    {
        private PinsKnockedDownMapper _mapper;

        [SetUp]
        public void CreateMapper()
        {
            _mapper = new PinsKnockedDownMapper();
        }

        [Test]
        public void EmptyMapsToEmpty()
        {
            var actual = _mapper.Map(Enumerable.Empty<int>());

            Assert.That(actual, Is.EquivalentTo(Enumerable.Empty<IRoll>()));
        }

    }
}