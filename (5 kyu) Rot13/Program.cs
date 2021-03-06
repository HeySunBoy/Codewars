using System;
using System.Linq;

namespace _5_kyu_Rot13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Rot13("Test13"));
        }

        public static string Rot13(string message)
        {
            string s = string.Empty;

            foreach (char c in message.ToCharArray())
            {
                if (c >= 'a' && c <= 'z')
                {
                    if (c + 13 > 'z')
                    {
                        s += (char)((c + 13) - 'z' + 'a' - 1);
                    }
                    else
                    {
                        s += (char)(c + 13);
                    }

                    continue;
                }

                if (c >= 'A' && c <= 'Z')
                {
                    if (c + 13 > 'Z')
                    {
                        s += (char)((c + 13) - 'Z' + 'A' - 1);
                    }
                    else
                    {
                        s += (char)(c + 13);
                    }

                    continue;
                }
                s += c;
            }

            return s;

        }
    }
}
