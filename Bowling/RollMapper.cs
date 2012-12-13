namespace Bowling
{
    public class RollMapper: IRollMapper<char>
    {
        public int Map(char input)
        {
            if (char.ToLowerInvariant(input) == 'x')
            {
                return 10;
            }

            return int.Parse(input.ToString());
        }
    }
}