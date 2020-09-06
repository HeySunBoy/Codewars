using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_kyu_Catching_Car_Mileage_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsInteresting(98, new List<int>() { 1337, 256 }));
        }

        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            int result = 2;

            foreach (string s in Array.ConvertAll(Enumerable.Range(number, 3).ToArray(), Convert.ToString))
            {
                if (s.Length >= 3)
                {
                    //1
                    if (awesomePhrases.IndexOf(Convert.ToInt32(s)) > -1)
                        return result;
                    //2
                    if (Convert.ToInt32(s) % Math.Pow(10, s.Length - 1) == 0)
                        return result;
                    //3
                    if (s.Distinct().Count() == 1)
                        return result;
                    //4
                    if (s == string.Concat(s.Reverse()))
                        return result;
                    //5  
                    if ("1234567890".Contains(s))
                        return result;
                    //6
                    if ("9876543210".Contains(s))
                        return result;
                }
                result = 1;
            }
            return 0;
        }
    }
}
