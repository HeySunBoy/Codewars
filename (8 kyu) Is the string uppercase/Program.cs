using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8_kyu__Is_the_string_uppercase
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.Write(IsUpperCase("HELLO I AM DONALD"));
        }

        public static bool IsUpperCase(this string text)
        {
            return text.ToUpper() == text;
        }

    }


}
