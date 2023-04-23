using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._6kata
{
	internal class IsANumberPrime
	{
		public static bool IsPrime(int n)
		{
			if(n <= 1) return false;
			if (n == 2) return true;
			if (n % 2 == 0) return false;

			int length = (int)Math.Round(Math.Sqrt(n), 0, MidpointRounding.AwayFromZero);

			for (var i = 2; i <= length; i++)
			{
				if (n % i == 0)
					return false;
			}

			return true;
		}
	}
}
