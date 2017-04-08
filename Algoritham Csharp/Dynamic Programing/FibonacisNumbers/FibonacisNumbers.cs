namespace FibonacisNumbers
{
    using System;

    class FibonacisNumbers
    {
        static int[] calculatatedNumbers;

        static void Main()
        {
            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                int number = int.Parse(line);
                calculatatedNumbers = new int[number];
                int result = GetFibonaciNumber(number);
                Console.WriteLine("Fibonacci of {0} is {1}", number, result);
                Console.SetCursorPosition(0, 0);
                line = Console.ReadLine();
            }
        }

        static int GetFibonaciNumber(int num)
        {
            if (num < 4)
            {
                if (num < 1)
                {
                    return 1;
                }

                return num;
            }
            else if (calculatatedNumbers[num - 1] != 0)
            {
                return calculatatedNumbers[num - 1];
            }
            else
            {
                int currNum = GetFibonaciNumber(num - 1) + GetFibonaciNumber(num - 2);
                calculatatedNumbers[num - 1] = currNum;
                return currNum;
            }
        }
    }
}
