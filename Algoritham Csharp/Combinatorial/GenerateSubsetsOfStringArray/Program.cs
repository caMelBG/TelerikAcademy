using System;

namespace GenerateSubsetsOfStringArray
{
    class Program
    {
        static string[] array =
        {
            "test", "rock", "fun"
        };
        static int k = 2;

        static void Main()
        {
            Recursion(0);
        }

        static void Recursion(int index)
        {
            if (true)
            {

            }
        }

        static void Print()
        {
            foreach (string word in array)
            {
                Console.Write(word + ", ");
            }

            Console.WriteLine();
        }
    }
}
