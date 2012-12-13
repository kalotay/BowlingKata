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
                try
                {
                    result = int.Parse(input.ToString());
                }
                catch (FormatException)
                {
                    throw new ArgumentException(string.Format("'{0}' is not a valid roll", input));
                }
            }

            _previous = result;
            return result;
        }
    }
}