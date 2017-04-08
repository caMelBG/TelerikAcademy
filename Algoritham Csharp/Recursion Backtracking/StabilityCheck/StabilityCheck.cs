namespace StabilityCheck
{
    using System;
    using System.Linq;

    class StabilityCheck
    {
        static int matrixSize;
        static int subMatrixSize;
        static int[][] matrix;
        static int bestSubMatrixSum;

        static void Main()
        {
            ReadInput();
            for (int i = 0; i <= matrixSize - subMatrixSize; i++)
            {
                for (int j = 0; j <= matrixSize - subMatrixSize; j++)
                {
                    Find(i, j);
                }
            }

            Console.WriteLine(bestSubMatrixSum);
        }

        static void Find(int row, int col)
        {
            int currentSum = 0;
            for (int i = row; i < row + subMatrixSize; i++)
            {
                for (int j = col; j < col + subMatrixSize; j++)
                {
                    currentSum += matrix[i][j];
                }
            }

            if (currentSum > bestSubMatrixSum)
            {
                bestSubMatrixSum = currentSum;
            }

        }

        static void ReadInput()
        {
            subMatrixSize = int.Parse(Console.ReadLine());
            matrixSize = int.Parse(Console.ReadLine());
            matrix = new int[matrixSize][];
            for (int i = 0; i < matrixSize; i++)
            {
                var line = Console.ReadLine();
                var parts = line.Split(' ');
                matrix[i] = new int[matrixSize];
                matrix[i] = parts.Select(x => int.Parse(x)).ToArray();
            }
        }
    }
}