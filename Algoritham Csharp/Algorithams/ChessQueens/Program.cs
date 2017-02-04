using System;

namespace ChessQueens
{
    class Program
    {
        static int n = 8;
        static int[,] board = new int[n, n];

        static int bestSum = 0;
        static int[,] bestBoard = new int[n, n];

        static void Main()
        {
            Solve(0, 0, 0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(bestBoard[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static void Solve(int index, int row, int col)
        {
            if (index > bestSum)
            {
                bestSum = index;
                bestBoard = board.Clone() as int[,];
            }

            for (int i = row; i < n; i++)
            {
                for (int j = col; j < n; j++)
                {
                    board[i, j] = 1;
                    Solve(index, i, j);
                    board[row, col] = 0;
                }
            }
        }
    }
}
