namespace StringComparing
{
    using System;

    class StringComparing
    {
        static void Main()
        {
            string first = "+abracadabra";
            string second = "+mabragabra";
            int n = first.Length;
            int m = second.Length;
            int[,] matrix = new int[n + 1, m + 1];
            int deleteCost = 1;
            int insertcost = 2;
            int replacecost = 3;

            replacecost = Solve(first, second, n, m, matrix, deleteCost, insertcost, replacecost);
            Print(first, second, n, m, matrix);

            while (n > 0 && m > 0)
            {
                int currNum = matrix[n, m];
                int upLeft = matrix[n - 1, m - 1];
                int left = matrix[n, m - 1];
                int up = matrix[n - 1, m];

                if (first[n - 1] != second[m - 1])
                {
                    if (currNum == upLeft + 3)
                    {
                        Console.WriteLine("Replace: {0}, {1}", m, second[m - 1]);
                    }
                    else if (currNum == up + 1)
                    {
                        Console.WriteLine("Delete: {0}", n - 1);
                        m++;
                    }
                    else if (currNum == left + 2)
                    {
                        Console.WriteLine("Insert: {0}", m - 1);
                        n++;
                    }
                }

                n--;
                m--;
            }

            n = first.Length;
            m = second.Length;
        }

        private static int Solve(string first, string second, int n, int m, int[,] matrix, int deleteCost, int insertcost, int replacecost)
        {
            /* Инициализиране */
            for (int i = 0; i <= n; i++)
            {
                matrix[i, 0] = i;
            }
            for (int i = 0; i <= m; i++)
            {
                matrix[0, i] = i;
            }

            /* Основен цикъл */
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int min = 0;
                    if (first[i - 1] == second[j - 1])
                    {
                        replacecost = 0;
                    }

                    min = matrix[i - 1, j - 1] + replacecost;
                    if (min > matrix[i - 1, j] + deleteCost)
                    {
                        min = matrix[i - 1, j] + deleteCost;
                    }
                    if (min > matrix[i, j - 1] + insertcost)
                    {
                        min = matrix[i, j - 1] + insertcost;
                    }

                    matrix[i, j] = min;
                    replacecost = 3;
                }
            }

            return replacecost;
        }

        private static void Print(string first, string second, int n, int m, int[,] matrix)
        {
            Console.Write("     ");
            foreach (var symbole in second)
            {
                Console.Write(symbole + "  ");
            }

            Console.WriteLine();
            for (int i = 0; i <= n; i++)
            {
                if (i > 0)
                {
                    Console.Write(first[i - 1] + " ");
                }
                else
                {
                    Console.Write("  ");
                }
                for (int j = 0; j <= m; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
