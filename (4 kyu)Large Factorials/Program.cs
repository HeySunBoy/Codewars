using System;
using System.Collections.Generic;


namespace _4_kyu_Large_Factorials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(0));
        }
        public static string Factorial(int n)
        {
            int[] s = new int[] { 1 };

            List<int> r1 = new List<int>();
            List<int> r2 = new List<int>();

            r1.Add(0);

            while (n > 0)
            {
                Console.WriteLine(n);
                char[] c = n.ToString().ToCharArray();
                //乘
                for (int i = c.Length - 1; i >= 0; i--)
                {
                    for (int j = s.Length - 1; j >= 0; j--)
                    {
                        r2.Insert(0, Convert.ToInt32(c[i].ToString()) * Convert.ToInt32(s[j]));
                    }
                    //補位
                    for (int x = 0; x < c.Length - 1 - i; x++)
                    {
                        r2.Add(0);
                    }

                    while (r1.Count < r2.Count)
                    {
                        r1.Insert(0, 0);
                    }

                    while (r2.Count < r1.Count)
                    {
                        r2.Insert(0, 0);
                    }

                    for (int z = r1.Count - 1; z >= 0; z--)
                    {
                        r1[z] += r2[z];
                        //進位
                        int a = r1[z] / 10;
                        r1[z] = r1[z] % 10;

                        if (a > 0)
                        {
                            if (z == 0)
                            {
                                r1.Insert(0, a);
                            }
                            else
                            {
                                r1[z - 1] += a;
                            }
                        }
                    }

                    r2.Clear();
                }


                s = r1.ToArray();
                r1.Clear();
                n--;
            }
            return String.Concat(Array.ConvertAll(s, Convert.ToString));
        }
    }
}
