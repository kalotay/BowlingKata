namespace Bowling
{
    public interface IStatefulFactory<out TGenerated, in TInput>
    {
        bool CanGenerate { get; }
        TGenerated GetInstance();
        void Register(TInput input);
    }
}