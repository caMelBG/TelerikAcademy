namespace YoungHacker
{
    using System;

    class Program
    {
        static int[] cardNumber;

        static void Main()
        {
            cardNumber = new int[16];
            Generate(0);
        }

        static void Generate(int index)
        {
            if (index == cardNumber.Length)
            {
                return;
            }

            if (IsLegit())
            {
                Print();
                Environment.Exit(0);
            }

            for (int i = 0; i <= 9; i++)
            {
                cardNumber[index] = i;
                Generate(index + 1);
            }

            cardNumber[index] = 0;
        }

        static void Print()
        {
            for (int i = 0; i < cardNumber.Length; i++)
            {
                Console.Write(cardNumber[i]);
                if ((i + 1) % 4 == 0 && i + 1 < cardNumber.Length)
                {
                    Console.Write(" - ");
                }
            }

            Console.WriteLine();
        }

        static bool IsLegit()
        {
            int[] temp = new int[cardNumber.Length];
            for (int i = 0; i < cardNumber.Length; i += 2)
            {
                temp[i] = cardNumber[i] * 2;
                temp[i + 1] = cardNumber[i];
            }

            int cardSum = 0;
            for (int i = 0; i < cardNumber.Length; i++)
            {
                if (temp[i] > 10)
                {
                    cardSum += (temp[i] - 10);
                }
                else
                {
                    cardSum += temp[i];
                }
            }

            if (cardSum == 60)
            {
                return true;
            }

            return false;
        }
    }
}