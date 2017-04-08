namespace Bridges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Bridges
    {
        static void Main()
        {
            Start();
        }

        static void Start()
        {
            var leftBridge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rigthBridge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[,] matrix = new int[rigthBridge.Length + 1, leftBridge.Length + 1];

            for (int i = 1; i <= rigthBridge.Length; i++)
            {
                for (int j = 1; j <= leftBridge.Length; j++)
                {
                    if (matrix[i, j] < matrix[i - 1, j])
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                    if (matrix[i, j] < matrix[i, j - 1])
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }
                    if (rigthBridge[i - 1] == leftBridge[j - 1])
                    {
                        matrix[i, j]++;
                    }
                }
            }

            Print(leftBridge, rigthBridge, matrix);
            Backwards(leftBridge, rigthBridge, matrix);
        }

        static void Backwards(int[] leftBridge, int[] rigthBridge, int[,] matrix)

        {
            var result = new Stack<int>();
            int value = matrix[rigthBridge.Length, leftBridge.Length];
            int x = rigthBridge.Length;
            int y = leftBridge.Length;
            while (value > 0)
            {
                while (matrix[x, y] == value)
                {
                    y--;
                }
                while (matrix[x, y + 1] == value)
                {
                    x--;
                }
                if (y <= rigthBridge.Length - 1)
                {
                    result.Push(leftBridge[y]);
                }

                value--;
            }

            int length = result.Count;
            Console.Write("Bridges: ");
            for (int index = 0; index < length; index++)
            {
                int number = result.Pop();
                Console.Write(number + "  ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Print(int[] leftBridge, int[] rigthBridge, int[,] matrix)
        {
            Console.WriteLine();
            Console.WriteLine("      " + string.Join("  ", leftBridge));
            Console.WriteLine();
            for (int i = 0; i <= rigthBridge.Length; i++)
            {
                if (i > 0 && i <= rigthBridge.Length)
                {
                    Console.Write(rigthBridge[i - 1] + "  ");
                }
                else
                {
                    Console.Write("   ");
                }

                for (int j = 0; j <= leftBridge.Length; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
