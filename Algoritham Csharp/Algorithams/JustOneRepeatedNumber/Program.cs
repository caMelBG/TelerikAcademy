using System;

namespace JustOneRepeatedNumber
{
    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            int number = int.Parse(line);
            int firstSum = 0;
            for (int i = 1; i < number; i++)
            {
                firstSum += i;
            }

            int randomNumber = GenerateRandomNumber(number);
            int secondSum = 0;
            for (int i = 1; i < number; i++)
            {
                if (i == randomNumber)
                {
                    secondSum += i;
                }

                secondSum += i;
            }

            var test = number * (number - 1) / 2;
            Console.WriteLine(test);
            Console.WriteLine(firstSum);
            Console.WriteLine(secondSum);
            Console.WriteLine("Repeated number is: " + (secondSum - firstSum));
        }

        static int GenerateRandomNumber(int num)
        {
            Random myRandom = new Random();
            int randomNumber = myRandom.Next(1, num);
            return randomNumber;
        }
    }
}
