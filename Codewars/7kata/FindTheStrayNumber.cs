using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._7kata
{
	internal class FindTheStrayNumber
	{
		public static int Stray(int[] numbers)
		{
			return numbers.Aggregate((a, b) => a ^ b);
		}
	}
}
