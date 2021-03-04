using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_kyu__Decode_the_Morse_code__advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            MorseCodeDecoder.DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011");
        }
    }

    public class MorseCode
    {
        public static string Get(string s)
        {
            return s;
        }
    }

    public class MorseCodeDecoder
    {
        public static string DecodeBits(string bits)
        {
            string[] bits_array = bits.Trim('0').Replace("10", "1 0").Replace("01", "0 1").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int min_length = bits_array.Min(o => o.Length);
            int max_length = bits_array.Max(o => o.Length);

            string dot = "1".PadRight(min_length, '1');
            string dash = "1".PadRight(min_length * 3, '1');
            string Pause_between_dots_and_dashes = "0".PadRight(min_length, '0');
            string Pause_between_characters_inside_a_word = "0".PadRight(min_length * 3, '0');
            string Pause_between_words = "0".PadRight(max_length, '0');

            string word = string.Empty;

            foreach (string strbits in bits_array)
            {
                if (strbits == dot)
                {
                    word += ".";
                }
                else if (strbits == dash)
                {
                    word += "-";
                }
                else if (strbits == Pause_between_dots_and_dashes)
                {
                    //do nothing
                }
                else if (strbits == Pause_between_characters_inside_a_word)
                {
                    word += "@";
                }
                else if (strbits == Pause_between_words)
                {
                    word += "@ @";
                }
            }
            return word;
        }

        public static string DecodeMorse(string morseCode)
        {
            string statement = string.Empty;

            foreach (string strMorseCode in morseCode.Split(new char[] { '@' }))
            {
                if (strMorseCode == " ")
                {
                    statement += " ";
                }
                else
                {
                    statement += MorseCode.Get(strMorseCode);
                }
            }
            return statement;
        }
    }
}
