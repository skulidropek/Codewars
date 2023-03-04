using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars._2kata
{
    /// <summary>
    /// 2 kyu Assembler interpreter (part II)
    /// https://www.codewars.com/kata/58e61f3d8ff24f774400002c
    /// </summary>
    public class AssemblerInterpreter
    {
        public static string RemoveSpace(string str)
        {
            while (str.Contains("  "))
                str = str.Replace("  ", " ");

            string[] array = str.Split('\n');

            str = "";

            for (int i = 0; i < array.Length; i++)
            {
                if (string.IsNullOrEmpty(array[i]))
                    continue;

                if (array[i].First() == ' ')
                    array[i] = array[i].Remove(0, 1);

                str += array[i] + "\n";
            }

            if (str.Last() == '\n')
                str = str.Remove(str.Length - 1, 1);

            return str;
        }

        public static string[] SplitMsg(string msg)
        {
            List<string> array = new List<string>();

            string message = "";
            if (msg.First() != '\'')
                message = "'";

                for (int i = 0; i < msg.Length; i++)
            {
                message += msg[i];

                if (message.Length > 2 && msg[i] == '\'')
                {
                    int length;

                    if (msg.Contains(message))
                    {
                        message = message.Replace("''", "'");
                        length = message.Length;
                    }
                    else
                    {
                        message = message.Replace("'", "");
                        length = message.Length;
                        message = message.Replace(",", "").Replace(" ", "");
                    }

                    msg = msg.Remove(0, length);
                    i -= length;

                    array.Add(message);
                    message = "'";
                    continue;
                }
            }

            if (!string.IsNullOrEmpty(message) && message.Length > 1)
            {
                message = message.Replace("'", "").Replace(",", "").Replace(" ", "");
                array.Add(message);
            }

            return array.ToArray();
        }

        public static string Interpret(string input)
        {
            Dictionary<string, int> register = new Dictionary<string, int>();
            Queue<int> gotoQueue = new Queue<int>();

            input = RemoveSpace(input);

            string input1 = input.Replace(",", "");

            string[] commands = input1.Split('\n');
            string[] commands2 = input.Split('\n');

            string result = "";
            int index = 0;

            int x = 0;
            int y = 0;

            while (index < commands.Length)
            {
                string command = commands[index];

                string[] param = command.Split(';').First().Split(' ');

                switch (param[0])
                {
                    case "mov":
                        {
                            if (!register.ContainsKey(param[1]))
                                register.Add(param[1], 0);

                            if (int.TryParse(param[2], out int number))
                            {
                                register[param[1]] = number;
                                break;
                            }

                            register[param[1]] = register[param[2]];
                        }
                        break;
                    case "inc":
                        register[param[1]] += 1;
                        break;
                    case "dec":
                        register[param[1]] -= 1;
                        break;
                    case "msg":
                        command = commands2[index];
                        param = SplitMsg(command.Replace("msg ", "").Split(';').First());

                        foreach (string param2 in param)
                        {
                            if (param2.Contains("'"))
                            {
                                result += param2.Remove(0, 1).Replace("'", "");
                                continue;
                            }

                            if (register.TryGetValue(param2.Replace(" ", ""), out int reg))
                            {
                                result += reg;
                                continue;
                            }

                            Console.WriteLine($"Команда {command} Индекс {index}. Регистр {param2} не обнаружен");
                        }
                        break;
                    case "add":
                        {
                            if (int.TryParse(param[2], out int number))
                            {
                                register[param[1]] += number;
                                break;
                            }
                            register[param[1]] += register[param[2]];
                        }
                        break;
                    case "sub":
                        {
                            if (int.TryParse(param[2], out int number))
                            {
                                register[param[1]] -= number;
                                break;
                            }
                            register[param[1]] -= register[param[2]];
                        }
                        break;
                    case "mul":
                        {
                            if (int.TryParse(param[2], out int number))
                            {
                                register[param[1]] *= number;
                                break;
                            }
                            register[param[1]] *= register[param[2]];
                        }
                        break;
                    case "div":
                        {
                            if (int.TryParse(param[2], out int number))
                            {
                                register[param[1]] /= number;
                                break;
                            }
                            register[param[1]] /= register[param[2]];
                        }
                        break;
                    case "call":
                        gotoQueue.Enqueue(index);
                        index = Array.IndexOf(commands, param.Last() + ":");
                        break;
                    case "ret":
                        index = gotoQueue.Dequeue();
                        break;
                    case "cmp":
                        {
                            if (!int.TryParse(param[1], out x))
                                x = register[param[1]];
                            if (!int.TryParse(param[2], out y))
                                y = register[param[2]];
                        }
                        break;
                    case "jmp":
                        {
                            if (x != y)
                            {
                                index = Array.IndexOf(commands, param.Last() + ":");
                            }
                        }
                        break;
                    case "je":
                        {
                            if (x == y)
                            {
                                index = Array.IndexOf(commands, param.Last() + ":");
                            }
                        }
                        break;
                    case "jge":
                        {
                            if (x >= y)
                            {
                                index = Array.IndexOf(commands, param.Last() + ":");
                            }
                        }
                        break;
                    case "jg":
                        {
                            if (x > y)
                            {
                                index = Array.IndexOf(commands, param.Last() + ":");
                            }
                        }
                        break;
                    case "jle":
                        {
                            if (x <= y)
                            {
                                index = Array.IndexOf(commands, param.Last() + ":");
                            }
                        }
                        break;
                    case "jl":
                        {
                            if (x < y)
                            {
                                index = Array.IndexOf(commands, param.Last() + ":");
                            }
                        }
                        break;
                    case "jne":
                        {
                            if(x != y)
                            {
                                index = Array.IndexOf(commands, param.Last() + ":");
                            }
                        }
                        break;
                    case "jnz":
                        {
                            int registerValue = register.ContainsKey(param[1]) ? register[param[1]] : 1;

                            if (registerValue == 0)
                                break;

                            index += int.Parse(param[2]) - 1;
                        }
                        break;
                    case "end":
                        return result;
                }

                index++;
            }

            return null;
        }
    }
}
