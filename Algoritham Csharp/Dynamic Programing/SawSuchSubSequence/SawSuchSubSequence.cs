namespace SawSuchSubSequence
{
    using System;
    using System.Collections.Generic;

    class SawSuchSubSequence
    {
        static int[] array = new int[] { 8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 };
        static Stack<int> numbers = new Stack<int>();

        static void Main()
        {
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] < array[index + 1])
                {
                    numbers.Push(array[index]);
                    FindMax(0, 1, 1);
                    break;
                }
                else
                {
                    numbers.Push(array[index]);
                    FindMin(0, 1, 1);
                    break;
                }
            }

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }

        static void FindMax(int index, int start, int length)
        {
            for (int i = start; i < array.Length; i++)
            {
                if (array[index] < array[i])
                {
                    if (numbers.Count == length)
                    {
                        numbers.Push(array[i]);
                    }
                    else
                    {
                        numbers.Pop();
                        numbers.Push(array[i]);
                    }

                    FindMin(i, i + 1, length + 1);
                }
            }
        }

        static void FindMin(int index, int start, int length)
        {
            for (int i = start; i < array.Length; i++)
            {
                if (array[index] > array[i])
                {
                    if (numbers.Count == length)
                    {
                        numbers.Push(array[i]);
                    }
                    else
                    {
                        numbers.Pop();
                        numbers.Push(array[i]);
                    }

                    FindMax(i, i + 1, length + 1);
                }
            }
        }
    }
}
