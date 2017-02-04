using System;

namespace MagicMatrix
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int[,] matrix = new int[num, num];
            int row = 0;
            int col = (num - 1) / 2;

            for (int index = 1; index <= num * num; index++)
            {
                matrix[row, col] = index;

                row -= 1;
                col += 1;
                if (row < 0)
                {
                    row = num - 1;
                }
                if (col == num)
                {
                    col = 0;
                }
                if (matrix[row, col] != 0)
                {
                    row += 2;
                    col -= 1;
                    if (row >= num)
                    {
                        row = 0;
                    }
                    if (col < 0)
                    {
                        col = num - 1;
                    }
                }
                if (matrix[row, col] != 0)
                {
                    row++;
                    if (row == num)
                    {
                        row = 0;
                    }
                }
            }

            Print(num, matrix);
        }

        static void Print(int num, int[,] matrix)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
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