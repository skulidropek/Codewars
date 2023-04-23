using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Codewars._6kata
{
    internal class Catalan
    {
        public static BigInteger NthCatalanNumber(int n) => Factorial(n * 2) / (Factorial(n) * Factorial(n)) / (n+1);

        static BigInteger Factorial(BigInteger n)
        {
            BigInteger factorial = 1;

            for (BigInteger i = 2; i <= n; i++)
                factorial = factorial * i;

            return factorial;
        }

        public static BigInteger NthCatalanNumberOld(int n)
        {
            BigInteger[] numbers = new BigInteger[n + 1];
            numbers[0] = 1;

            if (n >= 1)
            {
                numbers[1] = 1;
            }

            if (n >= 2)
            {
                numbers[2] = 2;
            }

            for (int x = 3; x <= n; x++)
            {
                int length = x / 2;

                for (int y = 0; y < length; y++)
                {
                    numbers[x] += numbers[y] * numbers[x - 1 - y] * 2;
                }

                if (x % 2 == 0)
                {
                    continue;
                }

                numbers[x] += numbers[length] * numbers[length];
            }

            return numbers[n];
        }
    }
}
