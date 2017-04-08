namespace Knapsack
{
    using System;

    class Knapsack
    {
        static int numbersOfItems = 3;
        static int maxValue = 0;
        static int maxWeigth = 16;
        static string usedItems = null;
        static int[] values = new int[] { 25, 16, 12, };
        static int[] weights = new int[] { 10, 8, 8, };

        static void Main()
        {
            Recursion(0, 0, usedItems);
            Console.WriteLine(usedItems);
        }

        static void Greedy(int index)
        {
            if (index == numbersOfItems)
            {
                return;
            }
            if (maxWeigth >= weights[index])
            {
                Console.WriteLine("Взема се 100% от предмет със стойност {0} и тегло {1}",
                    values[index], weights[index]);
                maxWeigth -= weights[index];
                maxValue += values[index];
                index++;
            }
            if (maxWeigth > 0)
            {
                double percentige = ((double)maxWeigth / (double)weights[index]) * 100;
                int valuePerWeigth = values[index] / weights[index];
                maxValue += (valuePerWeigth * maxWeigth);
                maxWeigth = 0;

                Console.WriteLine("Взема се {0}% от предмет със стойност {1} и тегло {2}",
                    percentige, values[index], weights[index]);
            }
            if (maxWeigth == 0)
            {
                Console.WriteLine("Обща получена цена: {0}", maxValue);
                return;
            }

            Greedy(index);
        }

        static void Recursion(int start, int currValue, string currItems)
        {
            if (maxValue < currValue)
            {
                usedItems = currItems;
                maxValue = currValue;
            }
            if (start == numbersOfItems)
            {
                return;
            }

            for (int index = start; index < numbersOfItems; index++)
            {
                if (weights[index] <= maxWeigth)
                {
                    maxWeigth -= weights[index];
                    Recursion(index + 1, currValue + values[index],
                        string.Format(currItems + "{0} ", (index + 1)));
                    maxWeigth += weights[index];
                }
            }
        }
    }
}
