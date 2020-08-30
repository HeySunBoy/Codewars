using System;
using System.Linq;

namespace _6_kyu__Decode_the_Morse_code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Decode(".... . -.--   .--- ..- -.. ."));
        }

        public static string Decode(string morseCode)
        {
            morseCode = morseCode.Trim().Replace("   ", "  ");

            string[] s = morseCode.Split(new char[] { ' ', '\r', '\n' });

            return string.Concat(s.Select(ss => TransMorseCodeToWord(ss)).ToArray());
        }

        static string TransMorseCodeToWord(string strMorseCode)
        {
            switch (strMorseCode)
            {
                case ".-":
                    return "A";
                case "-...":
                    return "B";
                case "-.-.":
                    return "C";
                case "-..":
                    return "D";
                case ".":
                    return "E";
                case "..-.":
                    return "F";
                case "--.":
                    return "G";
                case "....":
                    return "H";
                case "..":
                    return "I";
                case ".---":
                    return "J";
                case "-.-":
                    return "K";
                case ".-..":
                    return "L";
                case "--":
                    return "M";
                case "-.":
                    return "N";
                case "---":
                    return "O";
                case ".--.":
                    return "P";
                case "--.-":
                    return "Q";
                case ".-.":
                    return "R";
                case "...":
                    return "S";
                case "-":
                    return "T";
                case "..-":
                    return "U";
                case "...-":
                    return "V";
                case ".--":
                    return "W";
                case "-..-":
                    return "X";
                case "-.--":
                    return "Y";
                case "--..":
                    return "Z";
                case ".----":
                    return "1";
                case "..---":
                    return "2";
                case "...--":
                    return "3";
                case "....-":
                    return "4";
                case ".....":
                    return "5";
                case "-....":
                    return "6";
                case "--...":
                    return "7";
                case "---..":
                    return "8";
                case "----.":
                    return "9";
                case "-----":
                    return "10";
                case "...---...":
                    return "SOS";
                case "-.-.--":
                    return "!";
                case ".-.-.-":
                    return ".";
                default:
                    return " ";
            }
        }
    }
}
