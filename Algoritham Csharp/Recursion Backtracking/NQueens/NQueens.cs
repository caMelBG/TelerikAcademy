namespace NQueens
{
    using System;

    class NQueens
    {
        static int n;
        static char[][] board;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            FillingMatrix();

            Solve(0, 0, 0);
        }

        static void FillingMatrix()
        {
            board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new char[n];
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = '.';
                }
            }
        }

        static void Solve(int row, int col, int queens)
        {
            if (col == n)
            {
                col = 0;
                row++;
                if (row == n)
                {
                    return;
                }
            }

            if (queens == n)
            {
                Print();
                Environment.Exit(0);
            }

            if (CellIsEmpty(row, col))
            {
                board[row][col] = '*';
                Solve(row, col + 1, queens + 1);
                board[row][col] = '.';
            }

            Solve(row, col + 1, queens);
        }

        static bool CellIsEmpty(int row, int col)
        {
            for (int i = 0; i < n; i++)
            {
                if (row - i >= 0)
                {
                    if (col < n)
                    {
                        if (board[row - i][col] == '*')
                        {
                            return false;
                        }
                    }

                    if (col - i >= 0)
                    {
                        if (board[row - i][col - i] == '*')
                        {
                            return false;
                        }
                    }

                    if (col + i < n)
                    {
                        if (board[row - i][col + i] == '*')
                        {
                            return false;
                        }
                    }
                }

                if (row + i < n)
                {
                    if (col < n)
                    {
                        if (board[row + i][col] == '*')
                        {
                            return false;
                        }
                    }

                    if (col - i >= 0)
                    {
                        if (board[row + i][col - i] == '*')
                        {
                            return false;
                        }
                    }

                    if (col + i < n)
                    {
                        if (board[row + i][col + i] == '*')
                        {
                            return false;
                        }
                    }
                }

                if (row < n)
                {
                    if (col - i >= 0)
                    {
                        if (board[row][col - i] == '*')
                        {
                            return false;
                        }
                    }
                    if (col + i < n)
                    {
                        if (board[row][col + i] == '*')
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        static void Print()
        {
            foreach (char[] array in board)
            {
                foreach (char ch in array)
                {
                    Console.Write("   " + ch);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}