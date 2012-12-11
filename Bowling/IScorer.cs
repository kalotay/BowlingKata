using System;

namespace Bowling
{
    public interface IScorer<in T>
    {
        IComparable<int> Score { get; }
        void Register(T move);
        bool IsComplete { get; }
    }
}