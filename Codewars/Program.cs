using Codewars._2kata;
using Codewars._4kata;
using Codewars._5kata;
using Codewars._6kata;
using Codewars._7kata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Codewars
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var arra = MovingZerosToTheEnd.MoveZeroes(new int[] { 1, 2, 0, 3, 0, 4, 5, 6, 7});
            stopwatch.Stop();

            Console.WriteLine($"Время было затрачено {stopwatch.ElapsedMilliseconds} милисекунд");
            Console.ReadKey();
        }
    }
}
