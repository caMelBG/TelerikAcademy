using System;
using System.Collections.Generic;

namespace GenerateCombinationsIteratively
{
    class Program
    {
        static int n = 5;
        static int k = 3;

        static int[] array = new int[k];

        static void Main()
        {
            //ReadInput();
            Recursion(0, 0);
        }

        static void Recursion(int index, int start)
        {
            if (index == k)
            {
                Print();
                return;
            }

            for (int i = start; i < n; i++)
            {
                array[index] = i + 1;               
                Recursion(index + 1, i + 1);
            }
        }

        static void Print()
        {
            foreach (int number in array)
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine();
        }

        static void ReadInput()
        {
            Console.Write("n= ");
            n = int.Parse(Console.ReadLine());
            Console.Write("k= ");
            k = int.Parse(Console.ReadLine());
        }
    }
}