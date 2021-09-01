using System;
using System.Linq;

namespace DevTest.BL.Extensions
{
    public static class StringExtensions
    {
        public static string Reverse(this string input)
        {
            return new string(input.ToCharArray().Reverse().ToArray());
        }

        public static int CountVowels(this string input)
        {
            return input.Count(c => "aeiou".Contains(char.ToLower(c)));
        }

        public static int CountConsonants(this string input)
        {
            return input.Count(c => "bcdfghjklmnpqrstvwxyz".Contains(char.ToLower(c)));
        }
    }
}
