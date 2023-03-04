using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Codewars._4kata
{
    /// <summary>
    /// 4 kata Поиск неизвестной цифры
    /// https://www.codewars.com/kata/546d15cebed2e10334000ed9/train/csharp
    /// </summary>
    public class Runes
    {
        //Какое-то решение с кодеварса
        public static int solveExpression2(string expression)
        {
            string[] str = expression.Split('=');

            DataTable dt = new DataTable();
             
            for (int k = 0; k <= 9; k++)
            {
                if (expression.Contains(k.ToString()))
                    continue;

                Console.WriteLine(str[0].Replace('?', k.ToString()[0]));
                Console.WriteLine(dt.Compute(str[0].Replace('?', k.ToString()[0]), ""));

                if (dt.Compute(str[0].Replace('?', k.ToString()[0]), "").ToString() 
                    == str[1].Replace('?', k.ToString()[0]))
                    return k;
            }
            return -1;
        }

        //Моё решение
        public static int solveExpression(string expression)
        {
            int missingDigit = -1;

            List<char> symbols = new List<char>()
            {
                '*', '/', '+', '-'
            };

            char symbol = symbols.FirstOrDefault(s => expression.Contains(s));

            bool haveMinus = false;

            if (symbol == '-')
            {
                if (expression.First() == '-')
                {
                    expression = expression.Remove(0, 1);
                    haveMinus = true;
                }
            }

            for (int i = 0; i <= 9; i++)
            {
                if (expression.Contains(i.ToString()))
                     continue;

                string[] array = expression.Replace("?", i.ToString()).Split('=');

                string equals = array.Last();

                array = array.First().Split(new char[] { symbol }, 2);

                if (array.Length > 1)
                {
                    int x = int.Parse(array.First());

                    if(haveMinus)
                        x *= -1;

                    int y = int.Parse(array.Last());

                    int result = 0;

                    switch (symbol)
                    {
                        case '*':
                            result = x * y;
                            break;
                        case '/':
                            result = x / y;
                            break;
                        case '+':
                            result = x + y;
                            break;
                        case '-':
                            result = x - y;
                            break;
                    }

                    if(result.ToString() == equals)
                    {
                        missingDigit = i;
                        break;
                    }
                }
            }

            return missingDigit;
        }
    }
}
