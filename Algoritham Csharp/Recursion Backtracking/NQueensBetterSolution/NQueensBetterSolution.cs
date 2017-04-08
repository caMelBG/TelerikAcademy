namespace NQueensBetterSolution
{
    using System;
    using System.Collections.Generic;

    class NQueensBetterSolution
    {
        static int n = 8;
        static int[] rows = new int[n];
        static int[] cols = new int[n];
        static HashSet<int> firstDiagonal = new HashSet<int>();
        static HashSet<int> secondDiagonal = new HashSet<int>();

        static void Main()
        {
            Solve(0, 0, 0);
        }

        static void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cols[i] == j + 1)
                    {
                        Console.Write("  *");
                    }
                    else
                    {
                        Console.Write("  .");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void Solve(int row, int col, int queens)
        {
            if (queens == n)
            {
                Print();
                Environment.Exit(0);
            }
            if (col >= n)
            {
                col = 1;
                row++;
            }
            if (row >= n)
            {
                return;
            }
            if (!CheckIfIsUsed(row, col))
            {
                rows[row] = queens + 1;
                cols[col] = queens + 1;
                firstDiagonal.Add(row + col);
                secondDiagonal.Add(row - col);
                Solve(row, col + 1, queens + 1);
                secondDiagonal.Remove(row - col);
                firstDiagonal.Remove(row + col);
                cols[col] = 0;
                rows[row] = 0;
            }

            Solve(row, col + 1, queens);
        }

        static bool CheckIfIsUsed(int row, int col)
        {
            int firstDiagonalValue = row + col;
            int secondDiagonalValue = row - col;
            if (firstDiagonal.Contains(firstDiagonalValue) ||
                secondDiagonal.Contains(secondDiagonalValue))
            {
                return true;
            }
            else if (rows[row] != 0 || cols[col] != 0)
            {
                return true;
            }

            return false;
        }

    }
}
