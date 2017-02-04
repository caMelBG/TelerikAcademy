using System;
namespace FillingMatrix2
{
    class Program
    {
        static int[,] matrix;
        static int n;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            Solve();
            Print();
        }

        static void Solve()
        {
            int row = - 1;
            int col = - 1;
            int value = 1;
            int count = 0;
            while (value <= n * n)
            {
                row++;
                col++;
                //To Down
                while (matrix[row, col] == 0)
                {
                    matrix[row, col] = value;
                    value++;
                    row++;
                    if (row == n - count)
                    {
                        row--;
                    }
                }

                col++;
                //To Right
                while (matrix[row, col] == 0)
                {
                    matrix[row, col] = value;
                    value++;
                    col++;
                    if (col == n - count)
                    {
                        col--;
                    }
                }

                row--;
                // To Up
                while (matrix[row, col] == 0)
                {
                    matrix[row, col] = value;
                    value++;
                    row--;
                    if (row < count)
                    {
                        row++;
                    }
                }

                col--;
                //To Left
                while (matrix[row, col] == 0)
                {
                    matrix[row, col] = value;
                    value++;
                    col--;
                    if (col < count)
                    {
                        col++;
                    }
                }

                count++;
            }
        }

        static void Print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j].ToString().Length == 1)
                    {
                        Console.Write(" " + matrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
