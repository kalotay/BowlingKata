using System.Text.RegularExpressions;

namespace Bowling
{
    public class BowlingFilter
    {
        private static readonly Regex RegularExpression = new Regex(@"[^0-9xX\/]");

        public string Filter(string input)
        {
            return RegularExpression.Replace(input, string.Empty);
        }
    }
}