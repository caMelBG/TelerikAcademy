namespace PrintAllPathsFromTopLeftToBottomRight
{
    using System;

    class PrintAllPathsFromTopLeftToBottomRight
    {
        static int n = 2;
        static int[,] matrix = new int[n, n];

        static void Main()
        {
            FillingMatrix();
            FindPath(0, 0, null);
        }

        static void FindPath(int row, int col, string path)
        {
            if (row == n - 1 && col == n - 1)
            {
                path = path + matrix[row, col].ToString();
                Console.WriteLine(path);
                return;
            }

            if (row == n || col == n)
            {
                return;
            }

            string cell = matrix[row, col].ToString();
            path = path + cell + " - ";
            FindPath(row + 1, col, path);
            FindPath(row, col + 1, path);
        }

        static void FillingMatrix()
        {
            int step = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    step++;
                    matrix[i, j] = step;
                }
            }
        }
    }
}
