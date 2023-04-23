using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._4kata
{
	internal class StripCommentsSolution
	{
		public static string StripComments(string text, string[] commentSymbols)
		{
			if (string.IsNullOrWhiteSpace(text)) return "";

			string result = "";

			foreach (var str in text.Split('\n'))
			{
				foreach (var symbol in str)
				{
					if (commentSymbols.Contains(symbol.ToString()))
					{
						break;
					}

					result += symbol;
				}

				if (result.Length > 0)
					while (result.Last() == ' ')
						result = result.Remove(result.Length - 1);

				result += '\n';
			}

			if (result.Last() == '\n')
				result = result.Remove(result.Length - 1);

			return result;
		}
	}
}
