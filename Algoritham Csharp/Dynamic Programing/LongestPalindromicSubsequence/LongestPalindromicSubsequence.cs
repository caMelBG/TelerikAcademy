namespace LongestPalindromicSubsequence
{
    using System;

    class LongestPalindromicSubsequence
    {
        static void Main()
        {
            string input = "aanbbnnnbbba";
            //Solve(input);
            SolveWithClassicDynamicPrograming(input);
        }

        // complexity = n * (n / 2)
        static void Solve(string input)
        {
            int length = input.Length + 1;
            int[,] matrix = new int[length, length];
            for (int index = length; index >= 0; index--)
            {
                for (int j = 1; j < index; j++)
                {
                    int x = j - 1;
                    int y = j + (length - index);
                    matrix[x, y] = Math.Max(matrix[x + 1, y], matrix[x, y - 1]);
                    if (input[x] == input[y - 1])
                    {
                        if (matrix[x, y] > 0)
                        {
                            matrix[x, y] += 2;
                        }
                        else
                        {
                            matrix[x, y]++;
                        }
                    }
                }
            }

            Print(input, matrix);

        }
        // complexity = n * n
        static void SolveWithClassicDynamicPrograming(string input)
        {
            int length = input.Length;
            int[,] matrix = new int[length + 1, length + 1];

            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= length; j++)
                {
                    int leftIndex = j - 1;
                    int rigthIndex = length - i;

                    int upCell = matrix[i - 1, j];
                    int leftCell = matrix[i, j - 1];
                    int maxCell = Math.Max(upCell, leftCell);

                    if (input[leftIndex] == input[rigthIndex])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = maxCell;
                    }
                }
            }

            Print(input, matrix);
        }

        static void Print(string input, int[,] matrix)
        {
            int length = input.Length;
            Console.WriteLine("   " + string.Join("  ", input.ToCharArray()));
            for (int i = 0; i <= length; i++)
            {
                for (int j = 0; j <= length; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
