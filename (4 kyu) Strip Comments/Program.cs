using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace _4_kyu__Strip_Comments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(StripCommentsSolution.StripComments("\nE-\n\n\nF\n\nE\n\nF\nE\n\nA\n\nEBFAF\n\n\nC\n\nB\n\nE\n\n\nF-ADEBA\n\n--\n\nC\n\nDF\n\nD-\n\nA\n\nF\n\nDECA\n\n-D-\n\n\nC\n\n-\n\nD\n\nC\n\n-\n\nD\n\nFE\n\n-BFB\n\nB\n\n-FB\n\nFBDD\n\n\n\n\n\n-\n\nEBD\n\nBA\n\n\n\n\nA\nACDFDFDB\n\nA\n\nFE\n\nC\n\n\nEE\n\nD\n\nB\n\nF\n\nC\n\nB\n\nF\n\nB\n\nA\n\n-BD-\n\nB-B-\n\nA\n\nD\n\nF\n\n\n\nC\n\nEA\n\n\nB\n\nB\n\n-AB\n\n\n\n\n-D\n\nF\n\nD\n\nF\n\n\n\n\n\n\nF", new string[] { "#", "$", "!", "-" }));
            Console.Read();
        }
    }

    public class StripCommentsSolution
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            string regular_expression = string.Empty;

            foreach (string commentSymbol in commentSymbols)
            {
                regular_expression += "(" + (commentSymbol.Contains("$") ? "\\" + commentSymbol : commentSymbol) + ".*)|";
            }
            var v = text.Split(new char[] { '\n' }).Select(o => Regex.Replace(o, regular_expression.Trim(new char[] { '|' }), string.Empty).TrimEnd(' ')).ToList();
            return string.Join("\n", v.ToArray());
        }
    }
}
