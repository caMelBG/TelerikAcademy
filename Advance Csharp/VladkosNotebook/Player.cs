using System;
using System.Collections.Generic;

public class Player
{
    public static List<string> opponents = new List<string>();

    private static float wins = 0;

    private static float losses = 0;

    public static string Color { get; set; }

    public static string Name { get; set; }

    public static int Age { get; set; }

    public static void WrtiePlayer()
    {
        if (Player.Color != String.Empty && Player.Name != String.Empty && Player.Age != 0)
        {
            Console.WriteLine("Color: " + Player.Color);
            Console.WriteLine("-age: " + Player.Age);
            Console.WriteLine("-name: " + Player.Name);
            Console.Write("-opponents: ");
            if (opponents.Count != 0)
            {
                string[] temp = opponents.ToArray();
                Console.Write(string.Join(", ", temp));
            }

            else
            {
                Console.WriteLine("(empty)");
            }
            Console.WriteLine();

            Console.WriteLine("-rank: {0:0.##}" , GetRank());
        }
    }

    public static void Clear()
    {
        Player.opponents.Clear();
        Player.Color = string.Empty;
        Player.Name = string.Empty;
        Player.Age = 0;
        Player.wins = 0;
        Player.losses = 0;
    }

    public static void AddOpponent(string opponent)
    {
        Player.opponents.Add(opponent);
    }

    public static void AddWin()
    {
        Player.wins++;
    }

    public static void AddLoss()
    {
        Player.losses++;
    }

    public static float GetRank ()
    {
        Player.wins++;
        Player.losses++;
        if (Player.losses > 1)
        {
            return Player.wins / Player.losses;
        }

        else
        {
            return Player.wins;
        }

    }
}

