namespace Bowling
{
    public interface IBonusMultiplierQueue
    {
        void Enqueue(IRoll roll);
        int Dequeue();
    }
}