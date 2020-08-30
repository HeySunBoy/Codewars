using System;

namespace _7_kyu__Sum_of_odd_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(rowSumOddNumbers(42));
        }

        public static long rowSumOddNumbers(long n)
        {
            //n=8 row element count = 8 , all element count = (1 + n-1) * (n-1) / 2

            // i => n
            // 1 => 1 : n - i = i - 1
            // 2 => 3 : n - i = i - 1
            // 3 => 5 : n - i = i - 1
            // 4 => 7 : n - i = i - 1
            // n = 2i - 1 
            long nfirst = 2 * (((1 + n - 1) * (n - 1) / 2) + 1) - 1;

            long result = nfirst;

            while (n-- > 1)
                result += (nfirst += 2);

            return result;
        }
    }
}
