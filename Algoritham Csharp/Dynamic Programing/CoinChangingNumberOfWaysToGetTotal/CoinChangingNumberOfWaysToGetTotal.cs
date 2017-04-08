namespace CoinChangingNumberOfWaysToGetTotal
{
    using System;

    class CoinChangingNumberOfWaysToGetTotal
    {
        static int total = 5;
        static int[] coins = new int[] { 1, 2, 3, };
        static int[,] matrix = new int[coins.Length + 1, total + 1];

        static void Main()
        {
            //Interative();
            Recursion(1);
            Print();
        }

        static void Print()
        {
            for (int i = 0; i <= coins.Length; i++)
            {
                for (int j = 0; j <= total; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void Interative()
        {
            for (int i = 1; i <= coins.Length; i++)
            {
                matrix[i, 0] = 1;
                for (int j = 1; j <= total; j++)
                {
                    int currCoin = coins[i - 1];
                    if (j >= currCoin)
                    {
                        matrix[i, j] = matrix[i - 1, j] + matrix[i, j - currCoin];
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }
        }

        static void Recursion(int row)
        {
            if (row > coins.Length)
            {
                return;
            }

            matrix[row, 0] = 1;
            for (int col = 1; col <= total; col++)
            {
                int coin = coins[row - 1];
                if (col >= coin)
                {
                    matrix[row, col] = matrix[row - 1, col] + matrix[row, col - coin];
                }
                else
                {
                    matrix[row, col] = matrix[row - 1, col];
                }
            }

            Recursion(row + 1);
        }
    }
}
