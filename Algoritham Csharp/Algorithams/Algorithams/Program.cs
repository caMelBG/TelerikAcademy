using System;
using System.Linq;

namespace Algorithams
{
    class Program
    {
        static int n = 1;
        static int[] array = new int[n];
        static int[] soils = { 1, 1, 1, 1};

        static void Main()
        {
            //    n = int.Parse(Console.ReadLine());
            //    soils = Console.ReadLine()
            //       .Split(' ')
            //       .Select(x => int.Parse(x))
            //       .ToArray();

            Find(0, 0);

        }

        static void Find(int index, int start)
        {
            if (index >= n)
            {
                Print();
                return;
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    array[index] = i + 1;
                    Find(index + 1, i);
                }
            }
        }

        static void Print()
        {
            var soilsAsString  = soils.Select(x => x.ToString()).ToArray();
            Console.WriteLine(String.Join(", ", soilsAsString));
        }
    }
}
