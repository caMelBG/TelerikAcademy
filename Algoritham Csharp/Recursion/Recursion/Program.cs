namespace NestedLoopsToRecursion
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Recursion(number, 1);
        }

        private static void Recursion(int number, int index)
        {
            if (index > number)
            {
                return;
            }

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number; j++)
                {
                    Console.WriteLine($"{index} {i} {j}");
                }
            }

            Recursion(number, index + 1);
        }
    }
}
