using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class LittleJohn
{
    private static int smallArrows = 0;

    private static int mediumArrows = 0;

    private static int largeArrows = 0;

    private static string input;

    static void Main()
    {
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            input = myReader.ReadToEnd();
        }
        MatchArrows();
        Console.WriteLine(ConverOutput());
    }

    private static int ConverOutput()
    {
        string arrows = smallArrows.ToString() + mediumArrows.ToString() +
            largeArrows.ToString();

        string arrowsToBinary = Convert.ToString(int.Parse(arrows), 2);
        string arrowsToBinaryReverse = String.Empty;

        for (int i = arrowsToBinary.Length - 1; i >= 0; i--)
        {
            arrowsToBinaryReverse += arrowsToBinary[i];
        }

        int output = Convert.ToInt32(arrowsToBinary + arrowsToBinaryReverse, 2);

        return output;
    }

    private static void MatchArrows()
    {
        string pattern = ">>>----->>";

        while (true)
        {
            int index = input.IndexOf(pattern);

            if (index != -1)
            {
                if (pattern.Length == 10)
                {
                    input = input.Remove(index, 10);
                    largeArrows++;
                }

                else if (pattern.Length == 8)
                {
                    input = input.Remove(index, 8);
                    mediumArrows++;
                }

                else if (pattern.Length == 7)
                {
                    input = input.Remove(index, 7);
                    smallArrows++;
                }
            }

            else
            {
                if (pattern.Length == 10)
                {
                    pattern = pattern.Remove(9, 1);
                }
                pattern = pattern.Remove(0, 1);

                if (pattern.Length < 7)
                {
                    break;
                }
            }
        }
    }
}
