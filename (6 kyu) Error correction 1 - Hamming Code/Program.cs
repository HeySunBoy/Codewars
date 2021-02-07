using System;

namespace _6_kyu__Error_correction_1___Hamming_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(CodeWars.encode("hey"));
        }
    }

    public class CodeWars
    {
        public static string encode(string text)
        {
            char[] c = text.ToCharArray();
            string[] s = new string[c.Length];
            string bits = string.Empty;

            for (int i = 0; i < c.Length; i++)
            {
                s[i] = Convert.ToString(c[i], 2).PadLeft(8, '0');
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s[i].Length; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        bits += s[i].Substring(j, 1);
                    }
                }
            }
            return bits;
        }

        public static string decode(string bits)
        {
            string text = string.Empty;

            string bytes = string.Empty;

            for (int i = 0; i < bits.Length; i += 3)
            {
                string triples = bits.Substring(i, 3);
                bytes += (triples.IndexOf("1") == (triples.LastIndexOf("1"))) ? "0" : "1";

                if (bytes.Length == 8)
                {
                    text += Convert.ToChar(Convert.ToInt32(bytes, 2)).ToString();
                    bytes = string.Empty;
                }

            }

            return text;
        }
    }
}
