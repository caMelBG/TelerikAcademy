namespace BinomialCoefficient
{
    using System;

    class BinomialCoefficient
    {
        static void Main()
        {
            int k = 5;
            int n = 5;
            int[] array = new int[n + 1];
            Console.WriteLine(BinomialWithRecursion(n, k));
            Console.WriteLine(BinomialWithMemoization(n, k, array));

            int j = 0;
            for (int i = 0; i <= n; i++)
            {
                j = i > 1 ? i - 1 : 0;
                array[i] = 1;
                while (j > 0)
                {
                    array[j] += array[j - 1];
                    j--;
                }
            }
        }

        static int BinomialWithRecursion(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }
            else if (n == 0 || k == 0)
            {
                return 1;
            }
            else
            {
                return BinomialWithRecursion(n - 1, k - 1) + BinomialWithRecursion(n - 1, k);
            }
        }

        static int BinomialWithMemoization(int n, int k, int[] memoization)
        {
            int j = 0;
            for (int i = 0; i <= n; i++)
            {
                memoization[i] = 1;
                if (i > 1)
                {
                    j = i - 1;
                }

                for (; j >= 1; j--)
                {
                    memoization[j] += memoization[j - 1];
                }
            }

            return memoization[k];
        }
    }
}
