using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_kyu_The_observed_PIN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(',', GetPINs2("369").ToArray()));
        }

        //↓↓↓ Refactor Practice
        public static List<string> GetPINs2(string observed)
        {
            List<string> result = new List<string> { "" };

            foreach (char c in observed)
            {
                result = (from r in result
                          from n in AdjacentKeys[c]
                          select $"{r}{n}").ToList();
            }
            return result;
        }


        public static Dictionary<char, IEnumerable<string>> AdjacentKeys =
  new Dictionary<char, IEnumerable<string>>()
{
    { '1', new[] { "1", "2", "4" } },
    { '2', new[] { "1", "2", "3", "5" } },
    { '3', new[] { "2", "3", "6" } },
    { '4', new[] { "1", "4", "5", "7" } },
    { '5', new[] { "2", "4", "5", "6", "8" } },
    { '6', new[] { "3", "5", "6", "9" } },
    { '7', new[] { "4", "7", "8" } },
    { '8', new[] { "5", "7", "8", "9", "0" } },
    { '9', new[] { "6", "8", "9" } },
    { '0', new[] { "8", "0" } }
};

        //↓↓↓ First Practice
        public static List<string> GetPINs(string observed)
        {
            List<string> numlist = new List<string>();

            int[] s_index = new int[observed.Length];

            int[] index = new int[observed.Length];

            List<string> strReuslt = new List<string>();

            string s;

            for (int i = 0; i < observed.Length; i++)
            {
                s_index[i] = numlist.Count;
                index[i] = numlist.Count;
                inputnum(numlist, observed.Substring(i, 1));
            }

            while (true)
            {

                s = string.Empty;

                for (int i = 0; i < index.Length; i++)
                {
                    s += numlist[index[i]];
                }

                strReuslt.Add(s);

                index[index.Length - 1] += 1;

                for (int i = index.Length - 1; i > -1; i--)
                {
                    if (numlist[index[i]] == "#")
                    {
                        index[i] = s_index[i];

                        if (i == 0)
                        {
                            return strReuslt;
                        }
                        else
                        {
                            index[i - 1] += 1;
                        }
                    }

                }

            }
        }
        public static void inputnum(List<string> numlist, string _s)
        {

            switch (_s)
            {
                case "1":
                    numlist.Add("1");
                    numlist.Add("2");
                    numlist.Add("4");
                    break;
                case "2":
                    numlist.Add("1");
                    numlist.Add("2");
                    numlist.Add("3");
                    numlist.Add("5");
                    break;
                case "3":
                    numlist.Add("2");
                    numlist.Add("3");
                    numlist.Add("6");
                    break;
                case "4":
                    numlist.Add("1");
                    numlist.Add("5");
                    numlist.Add("4");
                    numlist.Add("7");
                    break;
                case "5":
                    numlist.Add("2");
                    numlist.Add("4");
                    numlist.Add("5");
                    numlist.Add("6");
                    numlist.Add("8");
                    break;
                case "6":
                    numlist.Add("3");
                    numlist.Add("5");
                    numlist.Add("6");
                    numlist.Add("9");
                    break;
                case "7":
                    numlist.Add("4");
                    numlist.Add("7");
                    numlist.Add("8");
                    break;
                case "8":
                    numlist.Add("5");
                    numlist.Add("7");
                    numlist.Add("8");
                    numlist.Add("9");
                    numlist.Add("0");
                    break;
                case "9":
                    numlist.Add("6");
                    numlist.Add("8");
                    numlist.Add("9");
                    break;
                case "0":
                    numlist.Add("0");
                    numlist.Add("8");
                    break;
            }
            numlist.Add("#");


        }




    }
}
