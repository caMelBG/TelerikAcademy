namespace MaximumCombinationOfActivities
{
    using System;

    class MaximumCombinationOfActivities
    {
        static int n = 7;
        static int[] start = new int[] { 3, 7, 5, 9, 13, 15, 17 };
        static int[] final = new int[] { 8, 10, 12, 14, 15, 19, 20 };

        static void Main()
        {
            Greeedy();
            Recursion(0, 0);
            Console.WriteLine();
        }

        static void Recursion(int index, int f)
        {
            if (index == 0)
            {
                Console.Write("Избрани лекции:");
            }
            if (index == n - 1)
            {
                return;
            }
            if (start[index] >= f)
            {
                Console.Write(" " + (index + 1));
                f = final[index];
            }

            Recursion(index + 1, f);
        }

        static void Greeedy()
        {
            int i = 1;
            int j = 2;

            Console.Write("Избрани лекции: " + i);
            while (j <= n)
            {
                if (start[j - 1] > final[i - 1])
                {
                    Console.Write(" " + j);
                    i = j;
                }

                j++;
            }

            Console.WriteLine();
        }
    }
}
