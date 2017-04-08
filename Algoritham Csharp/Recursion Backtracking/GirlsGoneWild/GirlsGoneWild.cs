namespace GirlsGoneWild
{
    using System;
    using System.Linq;

    class GirlsGoneWild
    {
        static int girls;
        static int[] shirts;
        static char[] skirds;
        static string[] output;

        static void Main()
        {
            ReadInput();
            Array.Sort(skirds);
            Solve(0, 0, 0);
        }

        static void Solve(int girlIndex, int shirtIndex, int skirdIndex)
        {
            if (girlIndex == girls)
            {
                Print();
            }
            else
            {
                for (int i = shirtIndex; i < shirts.Length; i++)
                {
                    for (int j = i; j < skirds.Length; j++)
                    {
                        int currShirt = shirts[i];
                        char currSkird = skirds[j];
                        var line = currShirt.ToString() + currSkird.ToString();
                        output[girlIndex] = line;
                        Solve(girlIndex + 1, i, skirdIndex + 1);
                    }
                }
            }
        }

        private static void Print()
        {
            foreach (string line in output)
            {
                Console.Write(line + " - ");
            }

            Console.WriteLine();
        }

        private static void ReadInput()
        {
            Console.Write("Girls: ");
            string line = Console.ReadLine();
            girls = int.Parse(line);
            Console.Write("Shirts: ");
            line = Console.ReadLine();
            shirts = Enumerable.Range(0, int.Parse(line)).ToArray();
            Console.Write("Skirds: ");
            line = Console.ReadLine();
            skirds = line.ToCharArray();
            output = new string[girls];
        }
    }
}