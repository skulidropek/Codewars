using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Codewars._2kata
{
	internal class Evaluate
	{
		static Dictionary<string, Operator> keyValuePairs = new Dictionary<string, Operator>()
		{
			{ "*", new Multiply() },
			{ "+", new Add() },
			{ "-", new Minus() },
			{ "/", new Divide() },
			{ "^", new RaiseToPower() },
		};

		public static string eval(string expression)
		{
			expression = RemoveWhiteSpaces(expression).ToLower();
			expression = expression.Replace("+", " + ").Replace("*", " * ").Replace("/", " / ").Replace("-", " - ").Replace("^", " ^ ").Replace("(", " ( ").Replace(")", " ) ").Replace("  ", " ");

			if (expression.Last() == ' ') expression = expression.Remove(expression.Length - 1);

			//string result = "0"; //calculated expression (double converted to string) or Errormessage starting with "ERROR" (+ optional Errormessage)
			return GetMathOperation(new Queue<string>(expression.Split(' '))).ToString();
		}

		public static double calculate(string s)
		{
			

			return SolveBracket(new Queue<string>(s.Split(' ')));
		}

		public static string RemoveWhiteSpaces(string str)
		{
			return Regex.Replace(str, @"\s+", String.Empty);
		}

		public static double SolveBracket(Queue<string> queue)
		{
			Stack<double> doubles = new Stack<double>();
			Stack<Operator> symbols = new Stack<Operator>();

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

					keyValuePairs[symbol].Result(value1, value2);
					continue;
				}

				symbols.Push(keyValuePairs[symbol]);
			}

			while (doubles.Count > 1)
			{
				Operator symbol = symbols.Pop();

				double x = doubles.Pop();
				double y = doubles.Pop();

				doubles.Push(symbol.Result(x, y));
			}

			return doubles.Last();
		}

		public static double GetMathOperation(Queue<string> queue)
		{
			MathOperation result = null;

			while (queue.Count > 0)
			{
				string symbol = queue.Dequeue();

				if (symbol == "(")
				{
					double value = GetMathOperation(queue);
					if (result == null)
						result = new MathOperation(value);
					else
						result.AddRight(value);
					continue;
				}
				else if (symbol == ")")
					break;

				if (double.TryParse(symbol, out double number))
				{
					MathOperation mathOperation = result;

					if (result == null)
						result = new MathOperation(number);
					else
						result.AddRight(number);
					continue;
				}

				if (symbol == "*" || symbol == "/" || symbol == "^")
				{
					string symbol2 = queue.Dequeue();

					result.AddRight(symbol2 == "(" ? SolveBracket(queue) : double.Parse(symbol2));
					result.AddOperator(symbol);
					continue;
				}

				result.AddOperator(symbol);
			}

			return result.Result();
		}

		public class MathOperation
		{
			private double _value;
			public double Value => _value;

			public MathOperation(double value)
			{
				_value = value;
			}
			 
			public double Result()
			{
				if(Right == null)
					return Value;

				double right = Right.Result();
				double answer = Operator.Result(_value, right);

				return answer;
			}

			public void AddRight(double value)
			{
				if(Right == null)
				{
					Right = new MathOperation(value);
					Right.Left = this;
					return;
				}

				Right.AddRight(value);
			}

			public void AddOperator(string mathOperator)
			{
				if (Operator == null)
				{
					Operator = keyValuePairs[mathOperator];
					return;
				}

				Right.AddOperator(mathOperator);
			}

			public MathOperation Left;
			public Operator Operator;
			public MathOperation Right;
		}

		public abstract class Operator
		{
			public abstract double Result(double x, double y);
		}

		public class Add : Operator
		{
			public override double Result(double x, double y) => x + y;
		}

		public class Minus : Operator
		{
			public override double Result(double x, double y) => x - y;
		}

		public class Multiply : Operator
		{
			public override double Result(double x, double y) => x * y;
		}

		public class Divide : Operator
		{
			public override double Result(double x, double y) => x / y;
		}	

		public class RaiseToPower : Operator
		{
			public override double Result(double x, double y) => Math.Pow(x, y);
		}
	}
}
