using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._7kata
{
	internal class BubblesortOnce
	{
		static int[] ss = new int[] { 3, 2, 1 };

		public static bool Equals(int[] x, int[] y)
		{
			for (int i = 0; i < x.Length; i++)
			{
				if (x[i] != y[i])
				{
					return false;
				}
			}

			return true;
		}

		public static int[] BubbleSortOnce(int[] UnsortedNumbers)
		{
			var result = (int[])UnsortedNumbers.Clone();
			for (var index = 1; index < result.Length; index++)
				if (result[index - 1] > result[index])
					(result[index - 1], result[index]) = (result[index], result[index - 1]);
			return result;
		}
	}
}
