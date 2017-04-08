namespace ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class ConnectedAreasInAMatrix
    {
        static List<char[]> matrix = new List<char[]>();
        static List<string> output = new List<string>();

        static int rows;
        static int cols;

        static int count = 0;
        static int size = 0;

        static void Main()
        {
            ReadInput();
            FindArea();
            Print();
        }

        static void FindArea()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == ' ')
                    {
                        Recursion(row, col);
                        AppendArea(row, col);
                    }
                }
            }
        }

        static void Recursion(int row, int col)
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
            size++;

            matrix[row][col] = '*';

            Recursion(row, col + 1);
            Recursion(row, col - 1);
            Recursion(row + 1, col);
            Recursion(row - 1, col);
        }

        static void AppendArea(int row, int col)
        {
            output.Add($"Area #{count} at ({row}, {col}), size: {size}");
            count++;
            size = 0;
        }

        static void Print()
        {
            Console.WriteLine($"Total areas found: {count}");
            foreach (string line in output)
            {
                Console.WriteLine(line);
            }
        }

        static void ReadInput()
        {
            var myReader = new StreamReader("..//..//input.txt");
            var currentLine = myReader.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                matrix.Add(currentLine.ToCharArray());
                currentLine = myReader.ReadLine();
            }

            rows = matrix.Count;
            cols = matrix[0].Length;
        }
    }
}