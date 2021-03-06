using System;
using System.Linq;

namespace _5_kyu_Common_Denominators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(convertFrac(new long[,] { }));
        }

        public static string convertFrac(long[,] lst)
        {
            string r = string.Empty;

            if (lst.Length == 0)
            {
                return r;
            }

            long c = lst.Length / 2;

            long[] n = new long[c];
            long[] d = new long[c];



            for (int i = 0; i < (c); i++)
            {
                n[i] = lst[i, 0];
                d[i] = lst[i, 1];

                long z = 2;

                while (true)
                {
                    if (z > Math.Min(n[i], d[i]))
                    {
                        break;
                    }

                    if ((n[i] % z == 0) && (d[i] % z == 0))
                    {
                        n[i] = n[i] / z;
                        d[i] = d[i] / z;
                    }
                    else
                    {
                        z++;
                    }
                }
            }


            long max = d.Max();

            Boolean flag = false;

            while (true)
            {

                flag = false;

                for (int i = 0; i < d.Length; i++)
                {
                    if (max % d[i] != 0)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    max += d.Max();
                }
                else
                {
                    break;
                }
            }

            long m;

            for (int i = 0; i < c; i++)
            {
                m = max / d[i];

                r += ($"({n[i] * m},{d[i] * m})");
            }


            return r;

        }
    }
}
