using System;

namespace BinarySearchTest
{
    class Program
    {
        static void Main()
        {
            int[] numbers = CreatArray();
            Find(numbers, 1);
        }

        static int[] CreatArray()
        {
            string line = "99";
            int num = int.Parse(line);
            int[] numbers = new int[num];

            for (int i = 1; i <= num; i++)
            {
                numbers[i - 1] = i;
            }

            return numbers;
        }

        static void Find(int[] array, int num)
        {
            int index = array.Length / 2;
            int value = array.Length / 4;
            while (true)
            {
                int curr = array[index];
                if (num == curr)
                {
                    Console.WriteLine(index + 1);
                    break;
                }
                else if (num < curr)
                {
                    Console.WriteLine(index + 1);
                    index = index - value;

                }
                else if (num > curr)
                {
                    Console.WriteLine(index + 1);
                    index = index + value;
                }

                if (value != 1)
                {
                    value = value / 2;
                }
            }
        }
    }
}
