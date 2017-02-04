using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Parachute
{
    static List<char[]> input;

    static void Main()
    {
        Read();
        MakeMoves();
    }

    static void MakeMoves()
    {
        string line = String.Empty;
        int jumperRow = 1;
        foreach (char[] item in input)
        {
            if (item.Contains('o'))
            {
                line = new string(item);
                break;
            }
            jumperRow++;
        }
        int jumperCol = line.IndexOf('o');
        int position = 0;

        for (int row = jumperRow; row < input.Count; row++)
        {
            line = new string(input[row]);
            for (int col = 0; col < line.Length; col++)
            {
                if (line[col] == '>')
                {
                    position++;
                }
                else if (line[col] == '<')
                {
                    position--;
                }
            }

            jumperCol += position;
            if (input[row][jumperCol] == '_')
            {
                Console.WriteLine("Landed on the ground like a boss!");
                Console.WriteLine(row + " " + jumperCol);
                break;
            }
            else if (input[row][jumperCol] == '~')
            {
                Console.WriteLine("Drowned in the water like a cat!");
                Console.WriteLine(row + " " + jumperCol);
                break;
            }
            else if (input[row][jumperCol] == '/' ||
                input[row][jumperCol] == '\\' ||
                input[row][jumperCol] == '|')
            {
                Console.WriteLine("Got smacked on the rock like a dog!");
                Console.WriteLine(row + " " + jumperCol);
                break;
            }
            position = 0;

        }
    }

    static void Read()
    {
        input = new List<char[]>();
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            string line = myReader.ReadLine();
            while (line != "END")
            {
                input.Add(line.ToCharArray());
                line = myReader.ReadLine();
            }
        }
    }
}

