using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._7kata
{
	internal class FindTheIndexOfTheSecondOccurrenceOfALetterInString
	{
		public static int SecondSymbol(string str, char symbol)
		{
			bool ishave = false;
			for (int i = 0; i < str.Length; i++)
				if (str[i] == symbol)
					if (ishave)
						return i;
					else
						ishave = true;

			return -1;
		}
	}
}
