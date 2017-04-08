namespace ResourseAllocation
{
    using System;

    class ResourseAllocation
    {
        static int max = 0;
        static int n = 5;
        static int k = 3;
        static int[,] memoization = new int[k, n + 1];
        static int[,] valuePerCity = new int[,]
            {
                { 0, 10, 15, 25, 40, 60 },
                { 0, 15, 20, 30, 45, 60 },
                { 0, 20, 30, 40, 50, 60 },
            };

        static void Main()
        {
            Solve(k - 1, n);

            Console.WriteLine(max);
        }

        static int Solve(int city, int cargo)
        {
            if (cargo == 0)
            {
                return 0;
            }
            else if (memoization[city, cargo] != 0)
            {
                return memoization[city, cargo];
            }
            else if (city == 0)
            {
                max = 0;
                for (int index = 0; index <= cargo; index++)
                {
                    if (max < valuePerCity[city, index])
                    {
                        max = valuePerCity[city, index];
                        memoization[city, cargo] = max;
                    }
                }

                return max;
            }
            else
            {
                max = 0;
                for (int index = 0; index <= cargo; index++)
                {
                    int currValue = valuePerCity[city, index] + Solve(city - 1, cargo - index);
                    if (max < currValue)
                    {
                        max = currValue;
                        memoization[city, cargo] = max;
                    }
                }

                return max;
            }
        }
    }
}
