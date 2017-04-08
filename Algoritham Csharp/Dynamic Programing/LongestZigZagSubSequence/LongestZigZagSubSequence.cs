namespace LongestZigZagSubSequence
{
    using System;

    class LongestZigZagSubSequence
    {
        static int[] array = new int[] { 8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 };
        static byte[] dp = new byte[array.Length];

        static void Main()
        {
            if (array[0] < array[1])
            {
                Solve(0, true);
            }
            else
            {
                Solve(0, false);
            }

            for (int index = 0; index < array.Length; index++)
            {  
                if (dp[index] == 1)
                {
                    if (index > 0)
                    {
                        if (array[index - 1] != array[index])
                        {
                            Console.Write(array[index] + " ");
                        }
                    }
                }
            }

            Console.WriteLine();
        }

        static void Solve(int index, bool findGreater)
        {
            if (index + 1 == array.Length)
            {
                return;
            }

            for (int i = index + 1; i < array.Length; i++)
            {
                if (findGreater)
                {
                    if (array[index] < array[i])
                    {
                        dp[index] = 1;
                        if (i + 1 == array.Length)
                        {
                            dp[i] = 1;
                            return;
                        }

                        Solve(i, false);
                    }
                }
                else
                {
                    if (array[index] > array[i])
                    {
                        dp[index] = 1;
                        if (i + 1 == array.Length)
                        {
                            dp[i] = 1;
                            return;
                        }

                        Solve(i, true);
                    }
                }
            }

            Solve(index + 1, findGreater);
        }

        static int SolveWithLinealComplexity()
        {
            byte[] x = new byte[array.Length];
            byte[] y = new byte[array.Length];

            for (int index = 0; index < array.Length - 1; index++)
            {
                if (array[index] < array[index + 1])
                {
                    x[index] = 1;
                }
                else
                {
                    y[index] = 1;
                }
            }

            int xLength = 1;
            int yLength = 1;
            for (int index = 1; index < x.Length; index++)
            {
                if (x[index - 1] != x[index])
                {
                    xLength++;
                }
                if (y[index - 1] != y[index])
                {
                    yLength++;
                }
            }

            return Math.Max(xLength, yLength);
        }
    }
}