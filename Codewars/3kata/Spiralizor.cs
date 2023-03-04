using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars._3kata
{

    /// <summary>
    /// 3 kyu Make a spiral
    /// https://www.codewars.com/kata/534e01fbbb17187c7e0000c6/train/csharp
    /// </summary>
    public class Spiralizor
    {
        public static int[,] Spiralize(int size)
        {
            int[,] result = new int[size, size];

            int x = 0;
            int y = 0;

            result[y, x] = 1;

            int sx = 1;
            int sy = 0;

            int minX = 0;
            int minY = 2;

            int maxX = size - 1;
            int maxY = size - 1;

            for (int i = 0; i < size; i++)
            {
                while (
                    (sx > 0 && x < maxX) ||
                    (sx < 0 && x > minX) ||
                    (sy > 0 && y < maxY) ||
                    (sy < 0 && y > minY)
                    )
                {
                    x += sx;
                    y += sy;
                    result[y, x] = 1;
                }

                if (sx < 0) minX = x + 2;
                if (sx > 0) maxX = x - 2;
                if (sy < 0) minY = y + 2;
                if (sy > 0) maxY = y - 2;

                int sxOld = sx;
                sx = -sy;
                sy = sxOld;

            }

            return result;
        }
    }
}
