using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._7kata
{
	internal class Factorial
	{
		public static ulong factorial(int n)
		{
			if (n < 0) return 0;

			ulong result = 1;
			for (uint i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}
	}
}
