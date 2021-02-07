using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _4_kyu__Most_frequently_used_words_in_a_text
{
    class Program
    {
        static void Main(string[] args)
        {
            TopWords.Top3(
            string.Join("\n", new string[] { "e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e" }));
        }
    }

    public class TopWords
    {
        public static List<string> Top3(string s)
        {
            var word = Regex.Matches(s.ToLower(), "['a-z]*[a-z]+['a-z]*").Cast<Match>().Select(match => match.Value).ToList();


            var q = (from p in word
                     group p by p into g
                     orderby g.Count() descending
                     select g).Take(3);

            List<string> result = new List<string>();

            foreach (var item in q.ToList())
            {
                result.Add(item.Key);
            }

            return result;
        }
    }
}