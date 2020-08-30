using System;
using System.Linq;

namespace _5_kyu__Maximum_subarray_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", MaxSequence(new int[] { })));
        }

        public static int MaxSequence(int[] arr)
        {
            if (arr.Count(n => n >= 0) == 0)
                return 0;
           
            int max = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    max = sum > max ? sum : max;
                }
            }

            return max;
        }
    }
}
