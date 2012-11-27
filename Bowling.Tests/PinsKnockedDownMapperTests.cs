using System.Linq;
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
        public void EmptyListReturnsEmpty()
        {
            var result = _mapper.Map(Enumerable.Empty<int>());

            Assert.That(result, Is.Empty);
        }

    }
}