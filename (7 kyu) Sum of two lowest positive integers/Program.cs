using System;
using System.Linq;

namespace _7_kyu__Sum_of_two_lowest_positive_integers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sumTwoSmallestNumbers(new int[] { 5, 8, 12, 19, 22 }));
        }

        public static int sumTwoSmallestNumbers(int[] numbers)
        {
            //↓↓↓ Refactor Practice
            return numbers.OrderBy(i => i).Take(2).Sum();

            //↓↓↓ First Practice
            Array.Sort(numbers);
            return numbers[0] + numbers[1];
        }
    }
}
