namespace Bowling
{
    public interface IRollMapper<in T>
    {
        int Map(T input);
    }
}