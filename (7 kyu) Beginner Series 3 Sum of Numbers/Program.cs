using System;

namespace _7_kyu__Beginner_Series_3_Sum_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSum(0, -1));
        }

        public static int GetSum(int a, int b)
        {
            //↓↓↓ Refactor Practice
            return ((a + b) * (Math.Abs(a - b) + 1)) / 2;

            //↓↓↓ First Practice
            int r = 0;

            for (int i = Math.Min(a, b); i <= Math.Max(a, b); i++)
                r += i;

            return r;
        }
    }
}
