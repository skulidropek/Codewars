using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._6kata
{
	internal class CountTheSmileyFaces
	{
		public static int CountSmileys(string[] smileys)
		{
			int lenght = 0;
			foreach(var smiley in smileys)
			{
				if(smiley.Length < 2)
					continue;

				switch (smiley.First())
				{
					case ':':
					case ';':
						if (smiley.Length > 2)
							switch (smiley[1])
							{
								case '-':
								case '~':
									break;

								default:
									continue;
							}

						switch (smiley.Last())
						{
							case ')':
							case 'D':
								lenght++;
								break;
						}
						break;
				}
			}

			return lenght;
		}
	}
}
