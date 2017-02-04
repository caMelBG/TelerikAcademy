using System;
using System.Collections.Generic;
using System.Text;

namespace Sowing
{
    public class SowingSolution
    {
        static int n;
        static List<int> goodSoilIndices = new List<int>();
        static StringBuilder output = new StringBuilder();
        static char[] field;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            field = Console.ReadLine()
                .Replace(" ", "")
                .ToCharArray();

            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] == '1')
                {
                    goodSoilIndices.Add(i);
                }
            }

            GenerateChukundur(0);
            Console.Write(output);
        }

        static void GenerateChukundur(int i, int sownSeeds = 0)
        {
            // All seed have been used
            if (sownSeeds == n)
            {
                Print();
                return;
            }

            // No more good soil left
            if (i == goodSoilIndices.Count)
            {
                return;
            }

            // Plant a seed if the previous soil has no chukundur
            var j = goodSoilIndices[i];
            var prevIsSeed = j > 0 && field[j - 1] == '.';
            if (!prevIsSeed)
            {
                field[j] = '.';
                GenerateChukundur(i + 1, sownSeeds + 1);
                field[j] = '1';
            }

            // Do not plant a seed
            GenerateChukundur(i + 1, sownSeeds);
        }

        static void Print()
        {
            foreach (var ch in field)
            {
                output.Append(ch);
            }

            output.AppendLine();
        }
    }
}
