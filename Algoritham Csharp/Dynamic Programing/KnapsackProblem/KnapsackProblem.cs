namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;

    class KnapsackProblem
    {
        static int totalWeight;
        static int itemsCount;
        static int[] itemWeight;
        static int[] itemValue;

        static void Main()
        {
            itemsCount = 4;
            totalWeight = 7;
            itemValue = new int[] { 1, 4, 5, 7, };
            itemWeight = new int[] { 1, 3, 4, 5, };
            Solve();
        }

        static void Print(int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < itemsCount + 1; i++)
            {
                for (int j = 0; j < totalWeight + 1; j++)
                {
                    Console.Write("  " + matrix[i, j]);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void Solve()
        {
            int[,] matrix = new int[itemsCount + 1, totalWeight + 1];
            for (int i = 1; i <= itemsCount; i++)
            {
                for (int j = 1; j <= totalWeight; j++)
                {
                    int prev = j - itemWeight[i - 1];
                    if (prev >= 0 && prev < itemsCount)
                    {
                        matrix[i, j] += itemValue[i - 1] + matrix[i - 1, prev];
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
            FindUsedItems(matrix);
        }

        static void FindUsedItems(int[,] matrix)
        {
            int x = itemsCount;
            int y = totalWeight;
            int value = matrix[x, y];
            var usedItems = new List<int>();
            while (y > 0)
            {
                while (matrix[x, y] == value)
                {
                    y--;
                }
                y++;
                while (matrix[x, y] == value)
                {
                    x--;
                }
                y = y - itemWeight[x];
                value = matrix[x, y];
                usedItems.Add(x);
            }

            Console.Write("Used Items: ");
            for (int index = usedItems.Count - 1; index >= 0; index--)
            {
                Console.Write(usedItems[index] + 1);
                if (index > 0)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void ReadInput()
        {
            Console.Write("Please insert item count: ");
            itemsCount = int.Parse(Console.ReadLine());
            itemWeight = new int[itemsCount];
            itemValue = new int[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                Console.Write("Item {0}: ", i + 1);
                string[] itemsParts = Console.ReadLine().Split(' ');
                itemWeight[i] = int.Parse(itemsParts[0]);
                itemValue[i] = int.Parse(itemsParts[1]);
            }

            Console.Write("Total weigth: ");
            totalWeight = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }
    }
}