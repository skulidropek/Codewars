using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Codewars._6kata
{
	internal class NumberFormat
	{
		public static string NumberFormat1(int number)
		{
			return Regex.Replace(number.ToString(), "(i)\\d{3}", "");
		}
	}
}
