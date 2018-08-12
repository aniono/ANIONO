using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const int M = 3;
            const int N = 3;
            int[,] m = new int[M,N]
            {
                { 0,1,2 },
                { 3,4,5 },
                { 6,7,8 }
            };

            int minPath = CaclMinPath(m);
            Console.WriteLine(minPath);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static int CaclMinPath(int[,] m)
        {
            int M = m.GetLength(0);
            int N = m.GetLength(1);
            int[,] dp = new int[M, N];

            for (int i = 0; i < M; i++)
            {
                dp[0, i] += m[0, i];
            }

            for (int i = 0; i < N; i++)
            {
                dp[i, 0] += m[i, 0];
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
    }
}
