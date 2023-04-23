using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._6kata
{
	//Find the unique number https://www.codewars.com/kata/585d7d5adb20cf33cb000235/train/csharp
	internal class Findtheuniquenumber
	{
		public static int GetUnique(IEnumerable<int> numbers) => numbers.FirstOrDefault(num => numbers.Count(s => num.Equals(s)) == 1);
	}
}