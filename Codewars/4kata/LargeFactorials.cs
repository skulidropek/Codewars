using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Codewars._4kata
{
    internal class LargeFactorials
    {
        public static string Factorial(int n)
        {
            string s = "1";

            for (int i = 1; i <= n; i++)
                s = MultiplyStrings(s, i.ToString());

            return s;
        }

        public static string MultiplyStrings(string a, string b)
        {
            string result = "";

            int r = 0;
            for (int i = b.Length - 1; i >= 0; i--)
            {
                string oldnNumber = "";

                int k = 0;

                for(int j = a.Length - 1; j >= 0 ; j--)
                {
                    int x = Convert.ToInt32(a[j].ToString());
                    int y = Convert.ToInt32(b[i].ToString());

                    string current = (x * y).ToString() + new string('0', k);
                    oldnNumber = SumStrings(oldnNumber, current);
                    k++;
                }

                result = SumStrings(result, oldnNumber + new string('0', r));

                r++;
            }

            return result;
        }

        public static string SumStrings(string a, string b)
        {
            var res = "";
            var c = 0;
            var aChars = new Stack<char>(a.ToCharArray());
            var bChars = new Stack<char>(b.ToCharArray());
            while (aChars.Count + bChars.Count + c > 0)
            {
                c += (aChars.Count > 0 ? (aChars.Pop() - '0') : 0) +
                    (bChars.Count > 0 ? (bChars.Pop() - '0') : 0);
                res = c % 10 + res;
                c /= 10;
            }
            return new Regex("^0").Replace(res, "");
        }

    }
}
