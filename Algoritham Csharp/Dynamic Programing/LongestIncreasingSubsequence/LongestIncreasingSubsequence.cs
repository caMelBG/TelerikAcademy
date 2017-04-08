namespace LongestIncreasingSubsequence
{
    using System;

    class LongestIncreasingSubsequence
    {
        static void Main()
        {
            int[] numbers = new int[] { 5, 4, -1, 3, 5, 7, 0, 1, 2 };
            int[] lis = new int[numbers.Length];
            for (int index = 1; index < numbers.Length; index++)
            {
                if (numbers[index - 1] < numbers[index])
                {
                    lis[index] = lis[index - 1] + 1;
                }
            }

            for (int index = 0; index < lis.Length; index++)
            {
                Console.Write(lis[index] + " ");
            }

            Console.WriteLine();

            int biggestSequence = 0;
            int startIndex = 0;
            for (int index = 0; index < lis.Length; index++)
            {
                if (lis[index] > biggestSequence)
                {
                    biggestSequence = lis[index];
                    startIndex = index;
                }
            }

            startIndex -= biggestSequence;
            for (int index = 0; index <= biggestSequence; index++)
            {
                Console.Write(numbers[startIndex + index] + "  ");
            }

            Console.WriteLine();
        }
    }
}
