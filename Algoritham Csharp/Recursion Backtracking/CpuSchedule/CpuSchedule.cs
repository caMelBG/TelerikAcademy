namespace CpuSchedule
{
    using System;

    class CpuSchedule
    {
        static int n = 5;
        static int maxValue = 0;
        static int[] taken = new int[n];
        static int[] numeration = new int[] { 5, 1, 2, 4, 3 };
        static int[] values = new int[] { 50, 40, 30, 20, 15 };
        static int[] dists = new int[] { 2, 1, 2, 1, 2 };

        static void Main()
        {
            string commontIncome = Solve(0, -1, string.Empty);

            Console.WriteLine("Оптимално разписание: " + commontIncome);
            Console.WriteLine("Общ доход: " + maxValue);
        }

        static string Solve(int start, int currDist, string used)
        {
            if (start == currDist)
            {
                return used;
            }

            int currValue = 0;
            int currNumer = 0;
            for (int index = 0; index < n; index++)
            {
                if (currDist < dists[index])
                {
                    currDist = dists[index];
                }

                if (currValue < values[index])
                {
                    for (int i = 0; i <= currDist; i++)
                    {
                        if (i == currDist)
                        {
                            currValue = values[index];
                            currNumer = numeration[index];
                            taken[start] = currNumer;
                            break;
                        }
                        else if (taken[i] == numeration[index])
                        {
                            break;
                        }
                    }
                }
            }

            maxValue += currValue;
            return Solve(start + 1, currDist, used + string.Format("{0} ", currNumer));
        }
    }
}
