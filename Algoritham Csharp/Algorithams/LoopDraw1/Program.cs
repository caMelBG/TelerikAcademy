using System;

namespace LoopDraw1
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = num; i > 0; i--)
            {
                Console.Write(new string(' ', i * 3));
                for (int j = i; j <= num; j++)
                {
                    if (j.ToString().Length == 1)
                    {
                        Console.Write(" " + j + " ");
                    }
                    else
                    {
                        Console.Write(j + " ");
                    }
                }

                for (int j = num - 1; j >= i; j--)
                {
                    if (j.ToString().Length == 1)
                    {
                        Console.Write(" " + j + " ");
                    }
                    else
                    {
                        Console.Write(j + " ");
                    }
                }

                Console.WriteLine(new string(' ', i));
                Console.WriteLine();
            }
        }
    }
}
