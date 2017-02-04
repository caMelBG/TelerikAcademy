using System;
using System.Linq;

namespace JustOneMissingNumber
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = GenerateArray(n);
            Console.WriteLine(String.Join(" ", numbers));
            var missingNumber = FindNumber(numbers);
            Console.WriteLine(missingNumber);
        }

        static int FindNumber(int[] numbers)
        {
            int prev = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                int curr = numbers[i];

                if (prev != curr - 1)
                {
                    return prev + 1;
                }

                prev = curr;
            }

            return 0;
        }

        static int[] GenerateArray(int n)
        {
            int[] numbers = Enumerable.Range(1, n + 1).ToArray();
            int[] result = new int[n];
            int missingNumber = GetRandomNumber(n);
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                if (missingNumber == numbers[i])
                {
                    index = 1;
                }

                result[i] = numbers[i + index];
            }

            return result;
        }

        static int GetRandomNumber(int n)
        {
            Random myRandom = new Random();
            int randomNumber = myRandom.Next(1, n + 1);
            return randomNumber;
        }
    }
}
