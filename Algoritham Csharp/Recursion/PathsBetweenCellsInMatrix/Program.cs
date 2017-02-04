using System;
using System.Collections.Generic;

namespace PathsBetweenCellsInMatrix
{
    class Program
    {
        static List<char[]> matrix = new List<char[]>();
        static List<char> steps = new List<char>();
        static int rows;
        static int cols;
        static int totalPaths;

        static void Main(string[] args)
        {
            ReadInput();
            FindPath(0, 0);
            Console.WriteLine($"Total paths found: {totalPaths}");
        }

        static void FindPath(int row, int col)
        {
            if (row < 0 || row >= rows ||
                col < 0 || col >= cols)
            {
                return;
            }
            else if (matrix[row][col] == '*')
            {
                return;
            }
            else if (matrix[row][col] == 'x')
            {
                return;
            }
            else if (matrix[row][col] == 'e')
            {
                Print();
                return;
            }

            matrix[row][col] = 'x';

            steps.Add('R');
            FindPath(row, col + 1);
            steps.RemoveAt(steps.Count - 1);

            steps.Add('L');
            FindPath(row, col - 1);
            steps.RemoveAt(steps.Count - 1);

            steps.Add('D');
            FindPath(row + 1, col);
            steps.RemoveAt(steps.Count - 1);

            steps.Add('U');
            FindPath(row - 1, col);
            steps.RemoveAt(steps.Count - 1);

            matrix[row][col] = ' ';
        }

        static void ReadInput()
        {
            string currentLine = Console.ReadLine();
            while (!string.IsNullOrEmpty(currentLine))
            {
                matrix.Add(currentLine.ToCharArray());
                currentLine = Console.ReadLine();
            }

            rows = matrix.Count;
            cols = matrix[0].Length; 
        }

        static void Print()
        {
            foreach (char symbole in steps)
            {
                Console.Write(symbole);
            }

            Console.WriteLine();
            totalPaths++;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <cols; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
