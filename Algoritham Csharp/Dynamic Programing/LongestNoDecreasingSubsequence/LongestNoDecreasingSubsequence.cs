namespace LongestNoDecreasingSubsequence
{
    using System;

    class LongestNoDecreasingSubsequence
    {
        static void Main()
        {
            int[] array = new int[] { 100, 10, 15, 5, 25, 22, 12, 22, 22, };
            int[] lns = new int[array.Length];
            int n = array.Length - 1;
            int max = 0;
            for (int i = 1; i <= n; i++)
            {
                lns[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] <= array[i])
                    {
                        if (lns[i] < lns[j] + 1)
                        {
                            lns[i] = lns[j] + 1;
                        }
                    }

                    if (lns[i] > max)
                    {
                        max = lns[i];
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}
