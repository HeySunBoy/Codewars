using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_kyu__Text_align_justify
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Kata.Justify(null, 123));
            Console.ReadKey();
        }
    }

    public static class Kata
    {
        public static string Justify(string str, int len)
        {

            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            string strResult = string.Empty;

            string tempStringList = string.Empty;

            string[] word = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string tempword in word)
            {
                if (string.IsNullOrEmpty(tempStringList))
                {
                    tempStringList += tempword;
                }
                else
                {
                    if ((tempStringList + " " + tempword).Length <= len)
                    {
                        tempStringList += " " + tempword;
                    }
                    else
                    {
                        string[] tempAddWord = tempStringList.Split(' ');
                        int spacecount = tempAddWord.Length - 1;

                        int totalspacenum = len - (tempStringList.Length - spacecount);

                        if (spacecount == 0)
                        {
                            strResult += tempStringList + "\n";
                        }
                        else
                        {
                            int addsapcenum = totalspacenum / spacecount;
                            int extraspacenum = totalspacenum % spacecount;

                            foreach (string AddWord in tempAddWord)
                            {
                                strResult += AddWord.PadRight(AddWord.Length + addsapcenum + ((extraspacenum > 0) ? 1 : 0));
                                extraspacenum -= 1;
                            }
                        }
                        strResult = strResult.Trim();
                        strResult += "\n";
                        tempStringList = tempword;
                    }
                }
            }

            strResult += tempStringList + "\n";
            strResult = strResult.Trim('\n');

            return strResult;
        }
    }
}
