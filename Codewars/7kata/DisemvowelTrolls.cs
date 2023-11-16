using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Codewars._7kata
{
	internal class DisemvowelTrolls
	{
		public static string Disemvowel(string str) => Regex.Replace(str, "[aeiouAEIOU]", "");
	}
}
