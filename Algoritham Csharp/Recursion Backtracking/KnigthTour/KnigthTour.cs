namespace KnigthTour
{
    using System;

    class KnigthTour
    {
        static int num;
        static int[,] board;
        static int[] xCord = new int[] { 1, 1, -1, -1, 2, -2, 2, -2 };
        static int[] yCord = new int[] { 2, -2, 2, -2, 1, 1, -1, -1 };

        static void Main()
        {
            num = 8;
            board = new int[num, num];
            Greedy(0, 0, 1);

        }

        static void RecursionWithBckTracking(int row, int col, int step)
        {
            board[row, col] = step;
            if (step == num * num)
            {
                Print();
                Environment.Exit(0);
            }

            for (int index = 0; index < xCord.Length; index++)
            {
                int x = xCord[index] + row;
                int y = yCord[index] + col;
                if (x >= 0 && y >= 0 && x < num && y < num)
                {
                    if (board[x, y] == 0)
                    {
                        RecursionWithBckTracking(x, y, step + 1);
                    }
                }
            }

            board[row, col] = 0;
        }

        static void Print()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    int num = board[i, j];
                    if (num < 10)
                    {
                        Console.Write("   " + num);
                    }
                    else
                    {
                        Console.Write("  " + num);
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void Greedy(int x, int y, int step)
        {
            if (step - 1 == num * num)
            {
                Print();
                Environment.Exit(0);
            }

            int minPosiblePostion = int.MaxValue;
            int nextRow = 0;
            int nextCol = 0;
            for (int index = 0; index < num; index++)
            {
                int row = x + xCord[index];
                int col = y + yCord[index];
                if (row >= 0 && row < num && col >= 0 && col < num)
                {
                    if (board[row, col] == 0)
                    {
                        int currPosiblePosition = CheckPosition(row, col);
                        if (minPosiblePostion > currPosiblePosition)
                        {
                            minPosiblePostion = currPosiblePosition;
                            nextRow = row;
                            nextCol = col;
                        }
                    }
                }
            }

            board[x, y] = step;
            Greedy(nextRow, nextCol, step + 1);
        }

        static int CheckPosition(int x, int y)
        {
            int countOfPosition = 0;
            for (int index = 0; index < num; index++)
            {
                int row = x + xCord[index];
                int col = y + yCord[index];
                if (row >= 0 && row < num && col >= 0 && col < num)
                {
                    if (board[row, col] == 0)
                    {
                        countOfPosition++;
                    }
                }
            }

            return countOfPosition;
        }
    }
}
