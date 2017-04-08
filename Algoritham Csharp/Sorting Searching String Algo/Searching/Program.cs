using System;

namespace Searching
{
    class Program
    {
        static int[] array;
        static int length = 9999;

        static void Main()
        {
            ArrayInitialization();
            var start = DateTime.Now;
            var result = BinarySearch(length);
            var end = DateTime.Now;
            Console.WriteLine("Binary Search result: " + (end - start));

            start = DateTime.Now;
            result = InterpolationSearch(length);
            end = DateTime.Now;
            Console.WriteLine("Interpolation result: " + (end - start));

            start = DateTime.Now;
            result = LinearSearch(length);
            end = DateTime.Now;
            Console.WriteLine("Linear Search result: " + (end - start));

        }

        static int LinearSearch(int value)
        {
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] == value)
                {
                    return index;
                }
            }

            return -1;
        }

        static int BinarySearch(int value)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (array[middle] == value)
                {
                    return middle;
                }
                else if (array[middle] > value)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }

        static int InterpolationSearch(int value)
        {
            int middle;
            int left = 0;
            int rigth = array.Length - 1;
            while (array[rigth] != array[left] && value >= array[left] && value <= array[rigth])
            {
                middle = left + ((value - array[left]) * (rigth - left)) / (array[rigth] - array[left]);
                if (array[middle] < value)
                {
                    left = middle + 1;
                }
                else if (value < array[middle])
                {
                    rigth = middle - 1;
                }
                else
                {
                    return middle;
                }
            }

            if (value == array[left])
            {
                return left;
            }
            else
            {
                return -1;
            }
        }

        static void ArrayInitialization()
        {
            array = new int[length];
            for (int i = 1; i <= length; i++)
            {
                array[i - 1] = i;
            }
        }
    }
}
