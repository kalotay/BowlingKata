using System.Collections.Generic;

namespace Bowling.Interface
{
    public interface IRollMapper<in T>
    {
        IEnumerable<IRoll> Map(IEnumerable<T> input);
    }
}