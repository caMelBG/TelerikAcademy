namespace RoadsideTrees
{
    using System;

    class RoadsideTrees
    {
        static int[] trees = new int[] { 0, 10, 20, 15, 40, 5, 4, 300, 2, 1 };
        static int[] incrThenDesc = new int[trees.Length];

        static void Main()
        {
            FindMaxIncreasingSubSequence();
            FindMaxDescendingSubSequence();
            Print();
        }

        static void Print()
        {
            int length = 0;
            int index = 0;
            for (int i = trees.Length - 1; i > 0; i--)
            {
                if (length <= incrThenDesc[i])
                {
                    length = incrThenDesc[i];
                    index = i;
                }
            }

            int sum = 0;
            int[] result = new int[length];
            for (int i = index; i > 0; i--)
            {
                if (length == incrThenDesc[i])
                {
                    sum += trees[i];
                    result[length - 1] = trees[i];
                    length--;
                }
            }

            var avg = ((double)sum) / result.Length;
            Console.WriteLine("Maximum number of trees that cat be trimed: {0}", result.Length);
            Console.WriteLine("Average height is: {0:F2}", avg);
            Console.WriteLine(string.Join(" ", result));
        }

        static void FindMaxDescendingSubSequence()
        {
            for (int i = 1; i < trees.Length; i++)
            {
                for (int j = i - 1; j > 0; j--)
                {
                    if (trees[j] > trees[i])
                    {
                        if (incrThenDesc[i] < incrThenDesc[j] + 1)
                        {
                            incrThenDesc[i] = incrThenDesc[j] + 1;
                        }
                    }
                }
            }
        }

        static void FindMaxIncreasingSubSequence()
        {
            for (int i = 1; i < trees.Length; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (trees[i] > trees[j])
                    {
                        if (incrThenDesc[i] < incrThenDesc[j] + 1)
                        {
                            incrThenDesc[i] = incrThenDesc[j] + 1;
                        }
                    }
                }
            }
        }
    }
}
