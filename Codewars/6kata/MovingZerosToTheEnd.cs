using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars._6kata
{
    internal class MovingZerosToTheEnd
    {
        public static int[] MoveZeroes(int[] arr) => arr.OrderBy(x => x == 0).ToArray();
    }
}
