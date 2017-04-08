namespace RatInAMaze
{
    using System;

    class RatInAMaze
    {
        static int n = 5;
        static byte[,] maze = new byte[5, 5]
            {
                { 0, 1, 0, 0, 0, },
                { 0, 0, 0, 1, 0, },
                { 0, 1, 1, 0, 0, },
                { 0, 0, 0, 0, 1, },
                { 0, 1, 1, 0, 0, },
            };

        static void Main()
        {
            FindPath(0, 0, null);
        }

        static void FindPath(int row, int col, string path)
        {
            if (row == n - 1 && col == n - 1)
            {
                Console.WriteLine(path);
                return;
            }
            if (row + 1 < n)
            {
                if (maze[row + 1, col] == 0)
                {
                    maze[row, col] = 1;
                    FindPath(row + 1, col, path + "Down, ");
                    maze[row, col] = 0;
                }
            }
            if (col + 1 < n)
            {
                if (maze[row, col + 1] == 0)
                {
                    maze[row, col] = 1;
                    FindPath(row, col + 1, path + "Rigth, ");
                    maze[row, col] = 0;
                }
            }
            if (row - 1 >= 0)
            {
                if (maze[row - 1, col] == 0)
                {
                    maze[row, col] = 1;
                    FindPath(row - 1, col, path + "Up, ");
                    maze[row, col] = 0;
                }
            }
            if (col - 1 >= 0)
            {
                if (maze[row, col - 1] == 0)
                {
                    maze[row, col] = 1;
                    FindPath(row, col - 1, path + "Left, ");
                    maze[row, col] = 0;
                }
            }
        }
    }
}
