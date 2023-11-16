using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._3kata
{
	internal class BattleshipFieldValidator
	{
		public static bool ValidateBattlefield(int[,] field)
		{
			var fieldToString = GetArray(field);

			int linkorsLength = 0;
			int kraiserLength = 0;
			int destroyersLength = 0;
			int submarinesLength = 0;

			for (int i = 0; i < fieldToString.Length; i++)
			{
				if (fieldToString[i] == 1)
				{
					if (fieldToString[i + 11] == 1 || fieldToString[i + 9] == 1)
						return false;

					if (IsKorabl(fieldToString, i, 4))
						linkorsLength++;
					else if (IsKorabl(fieldToString, i, 3))
						kraiserLength++;
					else if (IsKorabl(fieldToString, i, 2))
					{
						destroyersLength++;
					}
					else
					{
						submarinesLength++;
						fieldToString[i] = 0;
					}
				}
			}

			return linkorsLength == 1 && kraiserLength == 2 && destroyersLength == 3 && submarinesLength == 4;
		}

		public static bool IsKorabl(int[] fieldToString, int x, int length)
		{
			if (fieldToString.Length > x + length && fieldToString[x + 1] == 1)
			{
				for (int i = 2; i < length; i++)
				{
					if (fieldToString[i + x] != 1)
						return false;
				}

				for(int i = 0; i < length; i++)
				{
					fieldToString[i + x] = 0;
				}

				return true;
			}
			else if (fieldToString.Length > x + length * 10 && fieldToString[x + 10] == 1)
			{
				for (int i = 2; i < length; i++)
				{
					if (fieldToString[i * 10 + x] != 1)
						return false;
				}

				for (int i = 0; i < length; i++)
				{
					fieldToString[i * 10 + x] = 0;
				}

				return true;
			}

			return false;
		}

		public static int[] GetArray(int[,] field)
		{
			int[] array = new int[field.GetLength(0) * field.GetLength(1)];

			int z = 0;
			for (int y = 0; y < field.GetLength(0); y++)
			{
				for (int x = 0; x < field.GetLength(1); x++)
				{
					array[z] = field[y, x];
					z++;
				}
			}

			return array;
		}
	}
}
