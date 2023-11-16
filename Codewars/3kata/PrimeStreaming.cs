using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._3kata
{
	internal class PrimeStreaming
	{
		private static int[] _array = new int[MaxArrayLength];

		const int MaxArrayLength = 15_490_000;

		public static IEnumerable<int> Stream()
		{
			for(int i = 0; i < MaxArrayLength; i++)
				_array[i] = i;

			_array[1] = 0;
			int x = 2;

			while(x < MaxArrayLength)
			{
				if (_array[x] != 0)
				{
					int j = x + x;
					while(j < MaxArrayLength)
					{
						_array[j] = 0;
						j += x;
					}
				}
				x++;
			}

			List<int> array = new List<int>();

			for (int i = 0; i < MaxArrayLength; i++)
			{
				if (_array[i] == 0) continue;
				array.Add(_array[i]);
			}
			return array;
		}
	}
}
