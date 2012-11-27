using System.Collections.Generic;
using Bowling.Interface;
using System.Linq;

namespace Bowling
{
    public class PinsKnockedDownMapper: IRollMapper<int>
    {
        public IEnumerable<IRoll> Map(IEnumerable<int> input)
        {
            return Enumerable.Empty<IRoll>();
        }
    }
}