using System;

namespace Bowling
{
    public class RollMapper: IRollMapper<char>
    {
        private int _previous;

        public RollMapper()
        {
            _previous = 0;
        }

        public int Map(char input)
        {
            int result;

            if (char.ToLowerInvariant(input) == 'x')
            {
                result = 10;
            }
            else if (input == '/')
            {
                result = 10 - _previous;
            }
            else
            {
                if (!int.TryParse(input.ToString(), out result))
                {
                    throw new ArgumentException("Not a valid roll");
                }
            }

            _previous = result;
            return result;
        }
    }
}