namespace Sudoku
{
    using System;

    class Sudoku
    {
        static int[][] matrix = new int[9][];

        static void Main()
        {
            ReadInput();
            Solve(0, 0);
        }

        static void Solve(int row, int col)
        {
            if (col == 9)
            {
                col = 0;
                row++;
                if (row == 9)
                {
                    Print();
                }
            }

            if (matrix[row][col] == 0)
            {
                for (int i = 1; i < 10; i++)
                {
                    if (!IsContaints(row, col, i))
                    {
                        matrix[row][col] = i;
                        Solve(row, col + 1);
                        matrix[row][col] = 0;
                    }
                }
            }
            else
            {
                Solve(row, col + 1);
            }
        }

        static bool IsContaints(int row, int col, int number)
        {
            int toDown = matrix[0][0];
            int toUp = matrix[0][8];
            for (int i = 0; i < 9; i++)
            {
                if (matrix[i][col] == number)
                {
                    return true;
                }
                else if (matrix[row][i] == number)
                {
                    return true;
                }
                else if (i > 0)
                {
                    if (matrix[i][i] == toDown || matrix[8 - i][i] == toUp)
                    {
                        return true;
                    }
                }
            }

            row = (row / 3) * 3;
            col = (col / 3) * 3;
            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    if (matrix[i][j] == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine();
                }

                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0)
                    {
                        Console.Write("  ");
                    }

                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 21));
            Environment.Exit(0);
        }

        static void ReadInput()
        {
            for (int i = 0; i < 9; i++)
            {
                matrix[i] = new int[9];
                string line = Console.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    char symbole = line[j];
                    if (symbole == '-')
                    {
                        matrix[i][j] = 0;
                    }
                    else
                    {
                        matrix[i][j] = int.Parse(symbole.ToString());
                    }
                }
            }
        }
    }
}