namespace Election
{
    using System;
    using System.Collections.Generic;

    class Election
    {
        static Dictionary<char, int> parties = new Dictionary<char, int>();
        static Stack<char> currentParties = new Stack<char>();
        static int[] array;
        static int k;
        static int n;
        static int sum = 0;
        static int count = 0;

        static void Main()
        {
            ReadInput();
            Recursion(0);
            Console.WriteLine(count);
        }

        static void Recursion(int index)
        {
            if (sum >= n)
            {
                Print();
            }

            for (int i = index; i < k; i++)
            {
                sum += array[i];
                char symbole = Convert.ToChar(i + 65);
                currentParties.Push(symbole);
                Recursion(i + 1);
                currentParties.Pop();
                sum -= array[i];
            }
        }

        static void Print()
        {
            count++;
            foreach (var item in currentParties)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }

        static void ReadInput()
        {
            string currentLine = Console.ReadLine();
            n = int.Parse(currentLine);
            currentLine = Console.ReadLine();
            k = int.Parse(currentLine);
            array = new int[k];
            for (int i = 0; i < k; i++)
            {
                currentLine = Console.ReadLine();
                array[i] = int.Parse(currentLine);
            }
        }
    }
}