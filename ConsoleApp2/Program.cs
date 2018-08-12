using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static int CaclMinPath(int[,] m)
        {
            int M = m.GetLength(0);
            int N = m.GetLength(1);
            int[,] dp = new int[M, N];
            dp[0, 0] = m[0, 0];

            // first row
            for (int i = 1; i < M; i++)
            {
                dp[0, i] = dp[0, i - 1] + m[0, i];
            }

            // first column
            for (int i = 1; i < N; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + m[i, 0];
            }

            for (int i = 1; i < M; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    dp[i, j] += Math.Min(dp[i - 1, j], dp[i, j - 1]) + m[i, j];
                }
            }

            return dp[M - 1, N - 1];
        }

        public static int ReverseInteger(int x)
        {
            long result = 0;
            bool isNagative = false;
            int numOfDigits = 0;
            long[] nums = new long[16];

            if (x < 0)
            {
                isNagative = true;
                x = -x;
            }

            for (numOfDigits = 0; x > 0; numOfDigits++)
            {
                nums[numOfDigits] = x % 10;

                for (int i = 0; i < numOfDigits; i++)
                {
                    nums[i] *= 10;
                }

                if (nums[0] > int.MaxValue)
                    return 0;

                x /= 10;
            }

            for (int i = 0; i < numOfDigits; i++)
            {
                result += nums[i];

                if (result > int.MaxValue)
                    return 0;
            }

            return !isNagative ? (int)result : -(int)result;
        }
    }
}
