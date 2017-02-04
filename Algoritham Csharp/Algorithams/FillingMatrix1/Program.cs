using System;

namespace FillingMatrix1
{
    class Program
    {
        static int[,] matrix;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            int col = 0;
            int row = 1;

            for (int i = 1; i <= n * ((n - 1) / 2); i++)
            {
                matrix[row, col] = i;
                row++;
                if (row == n)
                {
                    col++;
                    row = col + 1;
                }
            }

            col = n - 1;
            row = n - 2;
            for (int i = n * ((n - 1) / 2) + 1; i <= n * (n - 1); i++)
            {
                matrix[row, col] = i;
                row--;
                if (row == -1)
                {
                    col--;
                    row = col - 1;
                }
            }

            Print(n);
        }

        static void Print(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j].ToString().Length == 1)
                    {
                        Console.Write(" " + matrix[i, j] + "  ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + "  ");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
