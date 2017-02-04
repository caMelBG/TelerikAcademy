using System;
using System.Collections.Generic;
using System.IO;

class VladkosNotebook
{
    private static List<string> input = new List<string>();

    public static List<Player> players = new List<Player>();

    static void Main()
    {
        ReadInput();
        FindPlayer();
    }

    public static void FindPlayer()
    {
        string color = input[0].Split('|')[0];

        Player.Color = color;

        foreach (string line in input)
        {
            string[] array = line.Split('|');

            if (array[0] == color)
            {
                AddPlayer(array);

            }

            else
            {
                Player.opponents.Sort();
                Player.WrtiePlayer();
                Player.Clear();
                Player.Color = array[0];
                color = array[0];
                AddPlayer(array);
            }
        }
        Player.WrtiePlayer();
    }

    public static void AddPlayer(string[] array)
    {
        if (array[1] == "name")
        {
            Player.Name = array[2];
        }

        else if (array[1] == "age")
        {
            Player.Age = int.Parse(array[2]);
        }

        else if (array[1] == "win")
        {
            Player.AddWin();
            Player.AddOpponent(array[2]);
        }

        else if (array[1] == "loss")
        {
            Player.AddLoss();
            Player.AddOpponent(array[2]);
        }
    }

    public static void ReadInput()
    {
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            string currentLine = myReader.ReadLine();

            while (currentLine != "END")
            {
                input.Add(currentLine);
                currentLine = myReader.ReadLine();
            }
            input.Sort();
        }
    }
}

