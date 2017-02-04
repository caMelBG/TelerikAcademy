using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class BiggestTableRow
{
    //TODO
    //Fix the Regex pattern

    static List<string> input = new List<string>();

    static List<string> bestNumber = new List<string>();

    static double bestSum = 0;

    static void Main()
    {
        ReadInput();
        FindBestTableRow();
        Print();
    }

    static void Print()
    {
        if (bestSum != 0)
        {
            Console.WriteLine
                (bestSum + " = " + string.Join<string>(" + ", bestNumber));
        }

        else
        {
            Console.WriteLine("(no data)");
        }
    }

    static void FindBestTableRow()
    {
        double currentSum = 0;
        Regex pattern = new Regex(@"\b[-]?[0-9]+[.]*[0-9]+\b");
        foreach (string line in input)
        {
            MatchCollection matches = pattern.Matches(line);
            foreach (Match match in matches)
            {
                currentSum += double.Parse(match.ToString());
            }

            if (currentSum > bestSum)
            {
                bestSum = currentSum;
                bestNumber.Clear();
                foreach (Match match in matches)
                {
                    bestNumber.Add(match.ToString());
                }
            }
            currentSum = 0;
        }
    }

    static void ReadInput()
    {
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            string currentLine = myReader.ReadLine();
            currentLine = myReader.ReadLine();
            currentLine = myReader.ReadLine();
            while (currentLine != "</table>")
            {
                input.Add(currentLine);
                currentLine = myReader.ReadLine();
            }
        }
    }
}

