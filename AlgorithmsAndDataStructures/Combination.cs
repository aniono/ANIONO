using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class Combination
    {
        public List<string> Generate(int r, int n)
        {
            var numOfCombinations = C2(n, r);
            Console.WriteLine($"Number of combinations: {numOfCombinations}");

            var result = new List<string>();
            var s = new char[r];
            for(int i = 0; i < r; i++)
            {
                s[i] = (char)(i + 1 + '0');
            }
            result.Add(string.Join("", s));

            for (int i = 1; i < numOfCombinations; i++)
            {
                int m = r - 1;
                char max = (char)(n + '0');
                while (s[m] == max)
                {
                    m--;
                    max--;
                }

                s[m]++;
                for (int j = m + 1; j < r; j++)
                {
                    s[j] = (char)(s[j - 1] + 1);
                }

                result.Add(string.Join("", s));
            }

            return result;
        }

        public int C(int n, int r)
        {
            //    n!
            // ---------
            // r!(n-r)!
            int s = 1;

            for (int i = n; i > r; i--)
                s *= i;

            for (int i = 1; i <= n - r; i++)
                s /= i;

            return s;
        }

        public int C2(int n, int r)
        {
            int i = n;
            int j = 2;
            int s = 1;

            while (i > r)
            {
                s *= i;
                while (s % j == 0)
                {
                    s /= j;
                    ++j;
                }

                --i;
            }

            return s;
        }
    }
}
