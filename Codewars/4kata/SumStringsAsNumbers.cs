using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._4kata
{
    internal class SumStringsAsNumbers
    {
        public static string sumStrings(string a, string b)
        {
            string result = "";
            int dop = 0;
            int index;
            int aOffset = 0;
            int bOffset = 0;

            if (a.Length > b.Length)
            {
                index = a.Length - 1;
                bOffset = index - (b.Length - 1);
            }
            else
            {
                index = b.Length - 1;
                aOffset = index - (a.Length - 1);
            }

            for (int i = index; i >= 0; i--)
            {
                int bNumber = 0;
                int aNumber = 0;

                if (i - aOffset >= 0)
                {
                    aNumber = int.Parse(a[i - aOffset].ToString());
                }

                if (i - bOffset >= 0)
                {
                    bNumber = int.Parse(b[i - bOffset].ToString());
                }

                string r = (aNumber + bNumber + dop).ToString();
                dop = 0;

                if (i != 0 && r.Length > 1)
                {
                    result = r.Last() + result;
                    dop = int.Parse(r.First().ToString());
                    continue;
                }

                result = r + result;
            }

            while (result.Length > 1 && result[0] == '0')
            {
                result = result.Remove(0, 1);
            }

            return result;
        }
    }
}
