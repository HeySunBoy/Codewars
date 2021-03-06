using System;

namespace _5_kyu_Double_Cola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WhoIsNext(new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" }, 15));
        }
        public static string WhoIsNext(string[] names, long n)
        {
            int i = 0;
            long x = 1;
            long p = 0;

            while (true)
            {
                if (n < x) return names[(i - 1 == -1) ? names.Length - 1 : i - 1];

                if (n == x) return names[i];

                x += (long)Math.Pow(2, p);

                i++;

                if (i == names.Length)
                {
                    i = 0;
                    p++;
                }
            }
        }



    }
}
