using System.Linq;

namespace YourPasswordSucks
{
    internal static class CharUtils
    {
        private const string SpecialChars = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

        public static bool IsSpecial(char c)
            => SpecialChars.Any(special => special == c);
    }
}