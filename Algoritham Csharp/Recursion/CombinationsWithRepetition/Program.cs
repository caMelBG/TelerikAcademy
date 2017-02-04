namespace CombinationsWithRepetition
{
    using System;

    class Program
    {
        private static int n;
        private static int k;
        private static int[] array;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            FillArray();
            Recursion(0, 0);
        }

        static void Recursion(int index, int start)
        {
            if (index >= k)
            {
                Print();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    array[index] = i + 1;
                    Recursion(index + 1, i);
                }
            }
        }
    

        private static int[] FillArray()
        {
            array = new int[k];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            return array;
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}