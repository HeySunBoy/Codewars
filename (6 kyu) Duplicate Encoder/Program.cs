using System;
using System.Linq;

namespace _6_kyu__Duplicate_Encoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DuplicateEncode("(( @"));
        }

        public static string DuplicateEncode(string word)
        {
            //↓↓↓ Refactor Practice
            word = word.ToUpper();
            return string.Concat(word.Select(x => word.Count(c => x == c) > 1 ? ')' : '(').ToArray());

            //↓↓↓ First Practice
            word = word.ToUpper();

            string strResult = string.Empty;

            foreach (char c in word.ToCharArray())
            {
                var a = from x in word
                        where x == c
                        select x;

                strResult += a.Count() > 1 ? ")" : "(";
            }
            return strResult;
        }
    }
}
