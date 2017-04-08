namespace TaxiCompany
{
    using System;

    class TaxiCompany
    {
        static int n = 10;
        static int k = 15;
        static int[] values;
        static int[] dist;
        static int[] last;

        static void Main()
        {
            Initialization();
            RecursiveMethod(1);
            //InterativeMethod();
            Print();
        }

        static void Initialization()
        {
            values = new int[] { 0, 12, 21, 31, 40, 49, 58, 69, 79, 90, 101, };
            dist = new int[k + 1];
            last = new int[k + 1];
            for (int index = 1; index <= k; index++)
            {
                dist[index] = int.MaxValue;
            }
        }

        static void Print()
        {
            if (last[k] != 0)
            {
                while (k != 0)
                {
                    int lastIndex = last[k];
                    int lastValue = values[lastIndex];
                    Console.WriteLine("Kilometar {0} per {1} value", lastIndex, lastValue);
                    k = k - lastIndex;
                }
            }

            Console.WriteLine();
            Console.WriteLine(string.Join(" ", last));
            Console.WriteLine(string.Join(" ", dist));
        }

        static void InterativeMethod()
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= k; j++)
                {
                    if (dist[j] >= dist[j - i] + values[i])
                    {
                        dist[j] = dist[j - i] + values[i];
                        last[j] = i;
                    }
                }
            }
        }

        static void RecursiveMethod(int start)
        {
            if (start > n)
            {
                return;
            }

            for (int index = start; index <= k; index++)
            {
                if (dist[index] >= dist[index - start] + values[start])
                {
                    dist[index] = dist[index - start] + values[start];
                    last[index] = start;
                }
            }

            RecursiveMethod(start + 1);
        }
    }
}
