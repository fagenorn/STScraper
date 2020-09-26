using System.Linq;
using System.Text.RegularExpressions;

namespace STScraper.Api
{
    public static class Utility
    {
        public static string ExtractEmail(this string text)
        {
            var regex        = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            var emailMatches = regex.Matches(text);

            return string.Join(',', emailMatches.Select(x => x.Value));
        }

        public static Match RegexMatch(this string text, string patern)
        {
            var regex = new Regex(patern, RegexOptions.IgnoreCase);

            return regex.Match(text);
        }
    }
}