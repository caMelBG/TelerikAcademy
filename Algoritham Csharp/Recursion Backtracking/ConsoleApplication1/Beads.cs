namespace Beads
{
    using System;

    class Beads
    {
        static int black;
        static int white;
        static string[] necklace;

        static void Main()
        {
            Console.Write("Black beads: ");
            black = int.Parse(Console.ReadLine());
            Console.Write("white beads: ");
            white = int.Parse(Console.ReadLine());
            Console.WriteLine();
            necklace = new string[(white * 2) + 1];
            for (int i = 1; i < necklace.Length; i += 2)
            {
                necklace[i] = "white";
            }

            Solve(0, 0);
        }

        static void Solve(int index, int start)
        {
            if (index == black)
            {
                Console.WriteLine(string.Join(" ", necklace));
                return;
            }

            for (int i = start; i < necklace.Length; i += 2)
            {
                necklace[i] = "black";
                Solve(index + 1, i + 2);
                necklace[i] = string.Empty;
            }
        }
    }
}