using System;
using System.Linq;

namespace Vowel_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetVowelCount("abracadabra"));
        }

        public static int GetVowelCount(string str)
        {
            //↓↓↓ Refactor Practice

            return str.Count(c => "aeiou".Contains(c));

            //↓↓↓ First Practice

            //int vowelCount = 0;

            //char[] element = new char[] { 'a', 'e', 'i', 'o', 'u' };


            //var result = from c in str.ToCharArray()
            //             where element.Contains(c)
            //             select c;

            //vowelCount = result.Count();

            //return vowelCount;
        }
    }
}
