using Codewars._2kata;
using Codewars._3kata;
using Codewars._4kata;
using Codewars._5kata;
using Codewars._6kata;
using Codewars._7kata;
using Codewars._8kata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Codewars
{
    internal class Program
    {
        static DateTime dateTime = new DateTime();
        public static void GetDateTime(string date)
        {
			var args1 = date.Split(':');

			int hours1 = int.Parse(args1[0]);
			int minus1 = int.Parse(args1[1]);

			dateTime = dateTime.AddHours(hours1).AddMinutes(minus1);
		}


        public static void Draw<T>(IEnumerable<T> values)
        {
            foreach(var value in values)
            {
                Console.WriteLine(value);
            }
        }

		static void Main(string[] args)
        {
			//Console.WriteLine("Введите количество элементов");
			//GetDateTime("04:48");
			//GetDateTime("01:33");
			//GetDateTime("00:26");
			//GetDateTime("01:19");

			//Draw(BubblesortOnce.BubbleSortOnce(new int[] { 3, 2, 1 }));

			Task.Run(() =>
			{
				bool arra1;
				Stopwatch stopwatch2 = new Stopwatch();
				stopwatch2.Start();
				arra1 = IsANumberPrime.IsPrime(int.MaxValue);
				stopwatch2.Stop();
				Console.WriteLine(arra1);
				Console.WriteLine($"Время было затрачено {stopwatch2.ElapsedMilliseconds} милисекунд");
			});
		

			//Task.Run(() =>
			//{
			//	string arra;
			//	Stopwatch stopwatch = new Stopwatch();
			//	stopwatch.Start();
			//	arra = Evaluate.eval("2 + 5 ^ 2 + 2");
			//	stopwatch.Stop();
			//	Console.WriteLine(arra);

			//	Console.WriteLine($"Время было затрачено на новый алгоритм {stopwatch.ElapsedMilliseconds} милисекунд");
			//});
		

			
			//Stopwatch stopwatch1 = new Stopwatch();
			//stopwatch1.Start();
			//arra = Catalan.catalan(number);
			//stopwatch1.Stop();
			//Console.WriteLine(arra);

			//Console.WriteLine($"Время было затрачено на рекурсивный алгоритм {stopwatch1.ElapsedMilliseconds} милисекунд");
			Console.ReadKey();
        }

    }
}
