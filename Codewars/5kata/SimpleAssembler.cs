using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars._5kata
{
    internal class SimpleAssembler
    {
        public void Draw(string[] program)
        {
            string message = "[MSG]";
            foreach(var item in program)
            {
                message += "\n" + item;
            }
            Console.WriteLine(message);
        }

        public static Dictionary<string, int> Interpret(string[] program)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            int index = 0;
            int Length = program.Length;


            while (index < Length)
            {
                string[] param = program[index].Split(' ');

                switch (param[0])
                {
                    case "mov":
                        if (!result.ContainsKey(param[1]))
                            result.Add(param[1], 0);

                        if (int.TryParse(param[2], out int number))
                        {
                            result[param[1]] = number;
                            break;
                        }

                        result[param[1]] = result[param[2]];
                        break;
                    case "inc":
                        result[param[1]] += 1;
                        break;
                    case "dec":
                        result[param[1]] -= 1;
                        break;
                    case "jnz":
                        int registerValue = result.ContainsKey(param[1]) ? result[param[1]] : 1;

                        if (registerValue == 0)
                            break;

                        index += int.Parse(param[2]) - 1;
                        break;
                }

                index++;
            }

            return result;
        }
        public static Dictionary<string, int> InterpretStack(string[] program)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            Stack<string> stack = new Stack<string>();

            for (int i = program.Length - 1; i >= 0; i--)
                stack.Push(program[i]);

            while (stack.Count > 0)
            {
                string command = stack.Pop();
                string[] param = command.Split(' ');

                int number = 0;

                switch (param[0])
                {
                    case "mov":
                        if (!result.ContainsKey(param[1]))
                            result.Add(param[1], 0);

                        if (int.TryParse(param[2], out number))
                        {
                            result[param[1]] = number;
                            continue;
                        }

                        result[param[1]] = result[param[2]];
                        break;
                    case "inc":
                        result[param[1]] += 1;
                        break;
                    case "dec":
                        result[param[1]] -= 1;
                        break;
                    case "jnz":
                        int index = result[param[1]];
                        int arrayIndex = Array.IndexOf(program, command);
                        number = int.Parse(param[2]);

                        if (index < 0)
                            index *= -1;

                        int maxIndex = arrayIndex + number;

                        if (index > 0)
                        {
                            if (number > 0)
                            {
                                for (int i = arrayIndex; i <= maxIndex; i++)
                                    stack.Push(program[i]);
                            }
                            else if (number < 0)
                            {
                                for (int i = arrayIndex; i >= maxIndex; i--)
                                    stack.Push(program[i]);
                            }
                        }

                        break;
                }
            }

            return result;
        }
    }
}
