using System;

namespace _6_kyu__Roman_Numerals_Encoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution(1000));
            Console.WriteLine(Solution(1954));
            Console.WriteLine(Solution(1990));
            Console.WriteLine(Solution(2008));
            Console.WriteLine(Solution(2014));
        }

        public static string Solution(int n)
        {

            int i = 1;

            string sn = n.ToString();

            string _s;

            string strResult = string.Empty;

            string roman;

            while (i <= sn.Length)
            {
                roman = string.Empty;
                _s = sn.Substring(sn.Length - i, 1);
                //4 //9
                switch (_s)
                {
                    case "0":
                        break;
                    case "4":
                        roman = Symbol("1".PadRight(i, '0')) + Symbol("5".PadRight(i, '0'));
                        break;
                    case "9":
                        roman = Symbol("1".PadRight(i, '0')) + Symbol("10".PadRight(i + 1, '0'));
                        break;
                    default:
                        while (Convert.ToInt32(_s) > 0)
                        {
                            if (Convert.ToInt32(_s) >= 5)
                            {
                                roman = Symbol("5".PadRight(i, '0'));
                                _s = (Convert.ToInt32(_s) - 5).ToString();
                            }
                            else
                            {
                                roman += Symbol("1".PadRight(i, '0'));
                                _s = (Convert.ToInt32(_s) - 1).ToString();
                            }
                        }
                        break;
                }

                strResult = roman + strResult;

                i++;
            }




            return strResult;
        }

        public static string Symbol(string n)
        {
            return (Convert.ToInt32(n)) switch
            {
                1 => "I",
                5 => "V",
                10 => "X",
                50 => "L",
                100 => "C",
                500 => "D",
                1000 => "M",
                _ => "",
            };
        }
    }
}
