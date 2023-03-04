using Codewars._2kata;
using Codewars._4kata;
using Codewars._5kata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Codewars
{
    internal class Program
    {
        private static string[] progs =
        {
            "\n; My first program\nmov  a, 5\ninc  a\ncall function\nmsg  '(5+1)/2 = ', a    ; output message\nend\n\nfunction:\n    div  a, 2\n    ret\n",
            "\nmov   a, 5\nmov   b, a\nmov   c, a\ncall  proc_fact\ncall  print\nend\n\nproc_fact:\n    dec   b\n    mul   c, b\n    cmp   b, 1\n    jne   proc_fact\n    ret\n\nprint:\n    msg   a, '! = ', c ; output text\n    ret\n",
            "\nmov   a, 8            ; value\nmov   b, 0            ; next\nmov   c, 0            ; counter\nmov   d, 0            ; first\nmov   e, 1            ; second\ncall  proc_fib\ncall  print\nend\n\nproc_fib:\n    cmp   c, 2\n    jl    func_0\n    mov   b, d\n    add   b, e\n    mov   d, e\n    mov   e, b\n    inc   c\n    cmp   c, a\n    jle   proc_fib\n    ret\n\nfunc_0:\n    mov   b, c\n    inc   c\n    jmp   proc_fib\n\nprint:\n    msg   'Term ', a, ' of Fibonacci series is: ', b        ; output text\n    ret\n",
            "\nmov   a, 11           ; value1\nmov   b, 3            ; value2\ncall  mod_func\nmsg   'mod(', a, ', ', b, ') = ', d        ; output\nend\n\n; Mod function\nmod_func:\n    mov   c, a        ; temp1\n    div   c, b\n    mul   c, b\n    mov   d, a        ; temp2\n    sub   d, c\n    ret\n",
            "\nmov   a, 81         ; value1\nmov   b, 153        ; value2\ncall  init\ncall  proc_gcd\ncall  print\nend\n\nproc_gcd:\n    cmp   c, d\n    jne   loop\n    ret\n\nloop:\n    cmp   c, d\n    jg    a_bigger\n    jmp   b_bigger\n\na_bigger:\n    sub   c, d\n    jmp   proc_gcd\n\nb_bigger:\n    sub   d, c\n    jmp   proc_gcd\n\ninit:\n    cmp   a, 0\n    jl    a_abs\n    cmp   b, 0\n    jl    b_abs\n    mov   c, a            ; temp1\n    mov   d, b            ; temp2\n    ret\n\na_abs:\n    mul   a, -1\n    jmp   init\n\nb_abs:\n    mul   b, -1\n    jmp   init\n\nprint:\n    msg   'gcd(', a, ', ', b, ') = ', c\n    ret\n",
            "\ncall  func1\ncall  print\nend\n\nfunc1:\n    call  func2\n    ret\n\nfunc2:\n    ret\n\nprint:\n    msg 'This program should return null'\n",
            "\nmov   a, 2            ; value1\nmov   b, 10           ; value2\nmov   c, a            ; temp1\nmov   d, b            ; temp2\ncall  proc_func\ncall  print\nend\n\nproc_func:\n    cmp   d, 1\n    je    continue\n    mul   c, a\n    dec   d\n    call  proc_func\n\ncontinue:\n    ret\n\nprint:\n    msg a, '^', b, ' = ', c\n    ret\n"
        };


        static void Main(string[] args)
        {
            //param = new string[]
            //{
            //   "mov a -10",
            //   "mov b a",
            //   "inc a",
            //   "dec b",
            //   "jnz a -2"
            //};

            string result;

            for(int i = 0; i < progs.Length; i++) 
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                result = AssemblerInterpreter.Interpret(progs[i]);
                stopwatch.Stop();
                Console.WriteLine(result);

                Console.WriteLine($"Время было затрачено {stopwatch.ElapsedMilliseconds} милисекунд");
            }

            //stopwatch = new Stopwatch();
            //stopwatch.Start();
            //result = SimpleAssembler.InterpretStack(param);
            //stopwatch.Stop();

            //Draw(result);
            //Console.WriteLine($"Время было затрачено {stopwatch.ElapsedMilliseconds} милисекунд");
            Console.ReadKey();
        }

        public static void Draw(Dictionary<string, int> keyValuePairs)
        {
            foreach (var pair in keyValuePairs)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }
        }

        public static bool PairOfShoes(int[][] shoes)
        {
            if (2 >= shoes.Length && shoes.Length >= 50)
            {
                Console.WriteLine("Первая проверка");
                return false;
            }


            for (int x = 0; x < shoes.Length; x++)
            {
                if (1 >= shoes[x][1] && shoes[x][1] >= 100)
                {
                    Console.WriteLine("Вторая проверка");
                    return false;
                }


                for (int y = 0; y < shoes[x].Length; y++)
                {
                    if (shoes[x][y] == -1) continue;

                    int index = -1;
                    int index2 = -1;
                    for (int x1 = 0; x1 < shoes.Length; x1++)
                    {
                        for (int y1 = 0; y1 < shoes[x1].Length; y1++)
                        {
                            if (shoes[x1][y1] == -1 || shoes[x][y] == -1) continue;

                            if (shoes[x1][y1] == shoes[x][y])
                            {
                                if (index != -1)
                                {
                                    if (shoes[index][index2] != -1)
                                    {
                                        shoes[index][index2] = -1;
                                        index = 1;
                                        index2 = -2;
                                    }

                                    shoes[x1][y1] = -1;
                                    index++;
                                }
                                else
                                {
                                    Console.WriteLine($"{x1} == {shoes.Length - 1} && {y1} == {shoes[x1].Length - 1}");
                                    if (x1 == shoes.Length - 1 && y1 == shoes[x1].Length - 1)
                                    {
                                        shoes[index][index2] = -1;
                                        index = 1;
                                        index2 = -2;
                                    }
                                    else
                                    {
                                        index = x1;
                                        index2 = y1;
                                    }
                                }
                            }
                        }
                    }

                    Console.WriteLine($"{index % 2 != 0} {index2}");
                    if (index % 2 != 0 && index2 == -2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool PairOfShoes1(int[][] shoes)
        {
            if (2 <= shoes.Length && shoes.Length <= 50)
                return false;

            for (int x = 0; x < shoes.Length; x++)
            {
                if (1 <= shoes[x][1] && shoes[x][1] <= 100)
                    return false;

                for (int y = 0; y < shoes[x].Length; y++)
                {
                    if (NumberCount(shoes[x][y], shoes) % 2 != 0)
                    {
                        // shoes = RemoveNumber(shoes[x][y], shoes);
                        return false;
                    }
                }
            }

            return true;
        }

        public static int[][] RemoveNumber(int number, int[][] shoes)
        {
            for (int x = 0; x < shoes.Length; x++)
            {
                for (int y = 0; y < shoes[x].Length; y++)
                {
                    if (shoes[x][y] == number)
                    {
                        shoes[x][y] = -1;
                    }
                }
            }
            return shoes;
        }

        public static int NumberCount(int number, int[][] shoes)
        {

            if (number == -1) return 0;
            int index = 0;

            for (int x = 0; x < shoes.Length; x++)
            {
                for (int y = 0; y < shoes[x].Length; y++)
                {
                    if (shoes[x][y] == number)
                    {
                        index++;
                        shoes[x][y] = -1;
                    }
                }
            }

            return index;
        }
    }
}
