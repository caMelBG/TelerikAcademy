namespace KnapsackRecursive
{
    using System;

    class KnapsackRecursive
    {
        static int totalWeight = 7;
        static int totalItems = 4;
        static int[] itemValue = new int[] { 1, 4, 5, 7 };
        static int[] itemWeight = new int[] { 1, 3, 4, 5 };
        static int[,] memoization = new int[totalItems + 1, totalWeight + 1];

        static void Main()
        {
            int result = Solve(totalItems - 1, totalWeight);
            Console.WriteLine(result);
        }

        static int Solve(int currItem, int currWeight)
        {
            if (memoization[currItem, currWeight] != 0)
            {
                return memoization[currItem, currWeight];
            }
            if (currItem == 0 || currWeight == 0)
            {
                return 0;
            }
            else if (itemWeight[currItem] > currWeight)
            {
                return Solve(currItem - 1, currWeight);
            }
            else
            {
                int firstValue = Solve(currItem - 1, currWeight);
                int secondValue = itemValue[currItem] +
                    Solve(currItem - 1, currWeight - itemWeight[currItem]);
                int max = Math.Max(firstValue, secondValue);
                memoization[currItem, currWeight] = max;
                return max;
            }
        }
    }
}
