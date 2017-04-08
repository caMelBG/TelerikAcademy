namespace SearchWordInMatrix
{
    using System;

    class SearchWordInMatrix
    {
        static int matrixSize = 5;
        static int movements = 8;
        static int[] rowCord = new int[] { 1, 1, 1, 0, 0, -1, -1, -1 };
        static int[] colCord = new int[] { 1, 0, -1, 1, -1, -1, 0, 1 };
        static char[,] matrix = new char[,]
        {
            {'t', 'z', 'x', 'c','d', },
            {'a', 'h', 'n', 'z','x', },
            {'h', 'w', 'o', 'i','o', },
            {'o', 'r', 'n', 'r','n', },
            {'a', 'b', 'r', 'i','n', },
        };

        static void Main()
        {
            Solve(0, 0, "horizon", 0);
        }

        static void Solve(int row, int col, string word, int step)
        {
            if (word.Length == step)
            {
                Print();
                Environment.Exit(0);
            }

            if (col == matrixSize)
            {
                col = 0;
                row++;
                if (row == matrixSize)
                {
                    return;
                }
            }
            if (word[step] == matrix[row, col])
            {
                for (int index = 0; index < movements; index++)
                {
                    if (row + rowCord[index] >= 0 && row + rowCord[index] < matrixSize &&
                        col + colCord[index] >= 0 && col + colCord[index] < matrixSize)
                    {
                        char symbole = matrix[row, col];
                        matrix[row, col] = (char)(step + 49);
                        Solve(row + rowCord[index], col + colCord[index], word, step + 1);
                        matrix[row, col] = symbole;
                    }
                }
            }

            Solve(row, col + 1, word, step);
        }

        static void Print()
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
