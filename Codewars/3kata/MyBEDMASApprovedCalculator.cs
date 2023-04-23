using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codewars._3kata
{
    internal class MyBEDMASApprovedCalculator
    {
		public static double calculate(string s)
		{
			s = RemoveWhiteSpaces(s);
			s = s.Replace("+", " + ").Replace("*", " * ").Replace("/", " / ").Replace("-", " - ").Replace("^", " ^ ").Replace("(", " ( ").Replace(")", " ) ").Replace("  ", " ");

			if (s.Last() == ' ') s = s.Remove(s.Length - 1);

			return SolveBracket(new Queue<string>(s.Split(' ')));
		}

		public static string RemoveWhiteSpaces(string str)
        {
            return Regex.Replace(str, @"\s+", String.Empty);
        }

		public static double SolveBracket(Queue<string> queue)
		{
			Stack<double> doubles = new Stack<double>();
			Stack<string> symbols = new Stack<string>();

			while (queue.Count > 0)
			{
				string symbol = queue.Dequeue();

				if (symbol == "(")
				{
					doubles.Push(SolveBracket(queue));
					continue;
				}
				else if (symbol == ")") break;

				if (double.TryParse(symbol, out double number))
				{
					doubles.Push(number);
					continue;
				}

				if (symbol == "*" || symbol == "/" || symbol == "^")
				{
					double value1 = doubles.Pop();
					string symbol2 = queue.Dequeue();

					double value2 = symbol2 == "(" ? SolveBracket(queue) : double.Parse(symbol2);

					switch (symbol)
					{
						case "*":
							doubles.Push(value1 * value2);
							break;
						case "/":
							doubles.Push(value1 / value2);
							break;
						case "^":
							doubles.Push(Math.Pow(value1, value2));
							break;
					}

					continue;
				}
				symbols.Push(symbol);
			}


			while (doubles.Count > 1)
			{
				string symbol = symbols.Pop();

				double x = doubles.Pop();
				double y = doubles.Pop();

				switch (symbol)
				{
					case "+":
						doubles.Push(y + x);
						break;
					case "-":
						doubles.Push(y - x);
						break;
					case "*":
						doubles.Push(y * x);
						break;
					case "/":
						doubles.Push(y / x);
						break;
					case "^":
						doubles.Push(Math.Pow(y, x));
						break;
				} 
			}

			return doubles.Last();
		}
	}
}
