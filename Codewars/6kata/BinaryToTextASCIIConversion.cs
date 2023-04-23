using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._6kata
{
	internal class BinaryToTextASCIIConversion
	{
		public static string BinaryToString(string binary)
		{
			var text = new StringBuilder();

			for(int y = 0; y < binary.Length / 8; y++)
			{
				string binaryCode = "";
				for(int x = 0; x < 8; x++)
					binaryCode += binary[x + y * 8];

				text.Append((char)Convert.ToByte(binaryCode, 2));
			}

			return text.ToString();
		}
	}
}
