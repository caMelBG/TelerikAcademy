namespace CoinChangingMinimumNumberOfCoins
{
    using System;

    class CoinChangingMinimumNumberOfCoins
    {
        static void Main()
        {
            int[] coins = new int[] { 1, 5, 6, 8, };
            int totalSum = 11;
            int[,] matrix = new int[coins.Length, totalSum + 1];

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = 1; j <= totalSum; j++)
                {

                    if (i > 0)
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }

                    int currCoin = coins[i];
                    if (j - currCoin >= 0)
                    {
                        matrix[i, j] = matrix[i, j - currCoin] + 1;
                        if (i > 0)
                        {
                            if (matrix[i, j] > matrix[i - 1, j])
                            {
                                matrix[i, j] = matrix[i - 1, j];
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = 0; j <= totalSum; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
