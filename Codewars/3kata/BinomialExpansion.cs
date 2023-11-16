using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Codewars._3kata
{
    internal class BinomialExpansion
    {
        public static string Expand(string expr)
        {
            var math = Regex.Match(expr, @"\((.*)(\+|\-|\*|\/)(.*)\)\^(\d)");

            X number1 = new X(math.Groups[1].ToString());
            string mathematicalSign = math.Groups[2].ToString();
            X number2 = new X(math.Groups[3].ToString());
            int degree = Convert.ToInt32(math.Groups[4].ToString());

            return number1.Pow(degree) + mathematicalSign + number1.Number * 2 * number2.Number + mathematicalSign + number2.Pow(degree);
        }

        class X
        {
            public int Number;
            public char Char;

            public X(string number)
            {
                var array = Regex.Match(number, @"(-?\d+)(\w)?").Groups;

                var argument1 = array[1].ToString();

                if (!int.TryParse(argument1, out Number))
                {
                    Char = argument1.First();
                    return;
                }

                char.TryParse(array[2].ToString(), out Char);
            }

            public string Pow(int pow)
            {
                return (Number * Number + "" + Char + $"^{pow}").Replace(" ", "");
            }

            public override string ToString()
            {
                return $"{Number}{Char}";
            }
        }
    }
}
