using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._8kata
{
	internal class RemoveFirstAndLastCharacter
	{
		public static string Remove_char(string s) =>  s.Remove(s.Length - 1).Remove(0, 1);
	}
}
