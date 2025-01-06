using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._7kata
{
    internal class FizzBuzz
    {
        public static string[] GetFizzBuzzArray(int n)
        {
            string[] result = new string[n];

            for (int i = 0; i < n; i++)
            {
                int index = i + 1;
                if (index % 3 == 0 && index % 5 == 0)
                {
                    result[i] = "FizzBuzz";
                }
                else if (index % 3 == 0)
                {
                    result[i] = "Fizz";
                }
                else if (index % 5 == 0)
                {
                    result[i] = "Buzz";
                }
                else
                {
                    result[i] = index.ToString();
                }
            }
            return result;
        }
    }
}
