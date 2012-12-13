namespace Bowling
{
    public class RollMapper: IRollMapper<char>
    {
        public int Map(char input)
        {
            return int.Parse(input.ToString());
        }
    }
}