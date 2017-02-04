using System;

namespace LoopDraw2
{
    class Program
    {
        static int num;

        static void Main()
        {
            num = int.Parse(Console.ReadLine());

            for (int index = 1; index <= num; index++)
            {
                Solve(index);
            }

            for (int index = num - 1; index > 0; index--)
            {
                Solve(index);
            }
        }

        static void Solve(int index)
        {
            int emptyEntries = (num - index) * 2;

            Console.Write(new string(' ', emptyEntries));

            for (int i = 1; i <= index; i++)
            {
                Console.Write(i + " ");
            }

            for (int i = index - 1; i > 0; i--)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(new string(' ', emptyEntries));
            Console.WriteLine();
        }
    }
}