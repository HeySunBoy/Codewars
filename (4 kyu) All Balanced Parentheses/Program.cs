using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_kyu__All_Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var warriorsList = new List<string>();
            warriorsList = Balanced.BalancedParens(4);
            warriorsList.Sort();
        }
    }

    public class Balanced
    {
        public static List<string> BalancedParens(int n)
        {
            List<string> r = new List<string>();

            int left_count = 0;
            int right_count = 0;

            if (n == 0)
            {
                r.Add(string.Empty);
                return r;
            }

            string s = "(";
            left_count = 1;

            JoinString(n, left_count, right_count, s, r);

            return r;
        }

        public static void JoinString(int n, int left_count, int right_count, string s, List<string> r)
        {
            if (left_count == right_count && right_count == n)
            {
                r.Add(s);
                return;
            }
            if (left_count < n)
            {
                JoinString(n, left_count + 1, right_count, s + "(", r);
            }
            if (right_count < left_count)
            {
                JoinString(n, left_count, right_count + 1, s + ")", r);
            }
        }
    }
}
