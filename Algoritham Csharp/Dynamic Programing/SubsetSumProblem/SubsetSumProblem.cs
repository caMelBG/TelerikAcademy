namespace SubsetSumProblem
{
    using System;

    class SubsetSumProblem
    {
        static int totalSum;
        static int[] numbers;

        static void Main()
        {
            //Console.Write("Total sum: ");
            //totalSum = int.Parse(Console.ReadLine());
            //numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            totalSum = 11;
            numbers = new int[] { 2, 3, 7, 8, 10 };
            Solve();

        }

        static void Solve()
        {
            int[,] matrix = new int[numbers.Length + 1, totalSum + 1];
            for (int i = 1; i <= numbers.Length; i++)
            {
                for (int j = 1; j <= totalSum; j++)
                {
                    if (numbers[i - 1] <= j)
                    {
                        int currNumber = numbers[i - 1];
                        int prevNumbers = matrix[i - 1, j - currNumber];
                        if (currNumber + prevNumbers <= j)
                        {
                            matrix[i, j] = currNumber + matrix[i - 1, j - currNumber];
                        }
                    }
                    if (matrix[i, j] < matrix[i - 1, j])
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                    if (matrix[i, j] < matrix[i, j - 1])
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }
                }
            }

            Print(matrix);
        }

        static void Print(int[,] matrix)
        {
            for (int i = 0; i <= numbers.Length; i++)
            {
                for (int j = 0; j <= totalSum; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
