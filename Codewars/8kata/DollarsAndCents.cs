using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._8kata
{
    internal class DollarsAndCents
    {
        public static string FormatMoney(double amount)
        {
            var ammountString = Math.Round(amount, 2).ToString();

            if (ammountString.Contains("."))
            {
                if (ammountString.Split('.')[1].Length == 1)
                {
                    return "$" + ammountString + "0";
                }

                return "$" + ammountString;
            }

            return "$" + ammountString + ".00";
        }
    }
}
