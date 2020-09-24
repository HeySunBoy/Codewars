using System;

namespace _4_kyu_Range_Extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 }));
        }

        public static string Extract(int[] args)
        {
            string s = string.Empty;

            Array.Sort(args);

            int start = 0;


            for (int i = 1; i <= args.Length; i++)
            {
                if ((i == args.Length) || ((args[start] + (i - start) != args[i])))
                {
                    switch (i - 1 - start)
                    {
                        case 0:
                            s += $",{args[start]}";
                            break;
                        case 1:
                            s += $",{args[start]},{args[i - 1]}";
                            break;
                        default:
                            s += $",{args[start]}-{args[i - 1]}";
                            break;
                    }
                    start = i;
                }
            }
            return s.Trim(',');
        }
    }
}
