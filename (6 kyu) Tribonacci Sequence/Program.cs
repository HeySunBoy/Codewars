using System;

namespace Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(',', Tribonacci(new double[] { 9, 11, 10 }, 2)));
        }

        public static double[] Tribonacci(double[] signature, int n)
        {
            //↓↓↓ First Practice
            double[] d = new double[n];

            for (int i = 0; i < d.Length; i++)
                d[i] = i < 3 ? signature[i] : d[i - 3] + d[i - 2] + d[i - 1];

            return d;
        }
    }
}
