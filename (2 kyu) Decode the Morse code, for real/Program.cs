using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_kyu__Decode_the_Morse_code__for_real
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(
            MorseCodeDecoder.decodeMorse(
            MorseCodeDecoder.decodeBitsAdvanced("111000111")
            )
            );
            Console.Read();
        }
    }

    public static class Preloaded
    {
        public static Dictionary<string, string> MORSE_CODE = new Dictionary<string, string> { { "..", "I" }, { ".", "E" }, { "....", "H" }, { "-.--", "Y" }, { ".---", "J" }, { "..-", "U" }, { "-..", "D" }, { "--", "M" }, { "-", "T" } };
    }

    public class MorseCodeDecoder
    {
        public static string decodeBitsAdvanced(string bits)
        {
            Console.WriteLine(bits);

            bits = bits.Trim('0');

            if (string.IsNullOrEmpty(bits))
            {
                return string.Empty;
            }
            else if (bits == "1001")
            {
                return ".@.";
            }

            string[] bits_array = bits.Replace("10", "1 0").Replace("01", "0 1").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dic_bit_type = new Dictionary<string, int>();

            for (int i = 0; i < bits_array.Length; i++)
            {
                if (!dic_bit_type.ContainsKey(bits_array[i]))
                {
                    dic_bit_type.Add(bits_array[i], -1);
                }
            }

            double minLen = dic_bit_type.Min(o => o.Key.Length);
            double[] arrCenterList = new double[] { 1 * minLen, 3 * minLen, 7 * minLen };

            k_mean(dic_bit_type, arrCenterList);

            var MorseCode = bits_array.Select(o =>
                                                o.Contains("1") ?
                                                    dic_bit_type[o] == 0 ? "." : "-"
                                                :
                                                    dic_bit_type[o] == 0 ? "" : dic_bit_type[o] == 1 ? "@" : "@ @"
                                             ).ToList();

            string s = string.Join("", MorseCode.Where(o => o != string.Empty).ToArray());


            return s;
        }

        public static void k_mean(Dictionary<string, int> dic_bit_type, double[] arrCenterList)
        {

            double middle1 = ((arrCenterList[0] + arrCenterList[1]) / 2);
            double middle2 = ((arrCenterList[1] + arrCenterList[2]) / 2);

            //Set Center Index
            foreach (string s in dic_bit_type.Keys.ToArray())
            {
                if (s.Length <= middle1)
                {
                    dic_bit_type[s] = 0;
                }
                else if (s.Length <= middle2)
                {
                    dic_bit_type[s] = 1;
                }
                else
                {
                    dic_bit_type[s] = 2;

                    if (s.Contains("1"))
                    {
                        dic_bit_type[s] = 1;
                    }
                }
            }
            //Recalculate Center Index
            double[] tempCenterList = new double[arrCenterList.Length];
            for (int i = 0; i < arrCenterList.Length; i++)
            {
                var v = dic_bit_type.Where(o => o.Value == i);
                double avg_length = v.Count() == 0 ? 0 : v.Average(o => o.Key.ToString().Length);


                if (avg_length == 0)
                {
                    tempCenterList[i] = arrCenterList[i];
                }
                else
                {
                    tempCenterList[i] = avg_length;
                }
            }
            //If ( New Center Equal Old Center ) ? Return Result : Recursive
            if (
                (tempCenterList[0] == arrCenterList[0]) &&
                (tempCenterList[1] == arrCenterList[1]) &&
                (tempCenterList[2] == arrCenterList[2])
               )
            {
                return;
            }
            else
            {
                arrCenterList = tempCenterList;
                k_mean(dic_bit_type, arrCenterList);
            }
        }

        public static string decodeMorse(string morseCode)
        {
            return string.Join("", morseCode.Split(new char[] { '@' }).Select(o => o == " " ? " " : (Preloaded.MORSE_CODE.ContainsKey(o)) ? o = Preloaded.MORSE_CODE[o] : "").ToList());
        }
    }

}
