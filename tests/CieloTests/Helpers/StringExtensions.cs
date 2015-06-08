using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CieloTests.Helpers
{
    public static class StringExtensions
    {
        public static string RemoveNewLinesAndSpaces(this string str)
        {
            return str.ExceptChars(new HashSet<char>(new[] {' ', '\t', '\n', '\r'}));
        }

        public static string ExceptChars(this string str, IEnumerable<char> toExclude)
        {
            var sb = new StringBuilder(str.Length);
            for (var i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (!toExclude.Contains(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}