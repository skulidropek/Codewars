using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._7kata
{
    internal class HighestAndLowest
    {
        public static string HighAndLow(string numbers)
        {
            string[] args = numbers.Split(' ');

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < args.Length; i++)
            {
                int number = int.Parse(args[i]);

                if (min > number)
                {
                    min = number;
                }

                if (max < number)
                {
                    max = number;
                }
            }

            return max + " " + min;
        }
    }
}
