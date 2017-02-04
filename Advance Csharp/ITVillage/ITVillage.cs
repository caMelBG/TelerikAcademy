using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class ITVillage
{
    static int inn = 0;

    static string dice;

    static List<int> movement = new List<int>();

    static void Main()
    {
        Read();

        int index = 0;
        int move = 0;
        int inns = 0;
        int coins = 50;

        while (true)
        {
            move += movement[index];
            move = move % 12;

            if (dice[move] == 'P')
            {
                coins -= 5;
            }
            else if (dice[move] == 'I')
            {
                if (coins >= 100)
                {
                    coins -= 100;
                    inns++;
                }
                else if (coins >= 10)
                {
                    coins -= 10;
                }
            }
            else if (dice[move] == 'F')
            {
                coins  += 20;
            }
            else if (dice[move] == 'S')
            {
                index += 2;
            }
            else if (dice[move] == 'V')
            {
                coins *= 10;
            }
            else if (dice[move] == 'N')
            {
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                break;
            }
            if (coins < 0)
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
                break;
            }
            index++;
            if (inns == inn && index >= movement.Count)
            {
                Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>", coins);
                break;
            }
            if (index >= movement.Count)
            {
                Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>", coins);
                break;
            }
        }
    }
    static void Read()
    {
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            StringBuilder temp = new StringBuilder();
            string[] symboles = myReader.ReadLine().Split('|').ToArray();
            string[][] matrix = new string[4][];
            int index = 0;
            foreach (var item in symboles)
            {
                matrix[index] = item.Trim().Split(' ').ToArray();
                index++;
            }
            string[] cord = myReader.ReadLine().Split(' ');
            int row = int.Parse(cord[0]) - 1;
            int col = int.Parse(cord[1]) - 1;
            movement = myReader.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (row == 0)
                {
                    while (col <= 3)
                    {
                        if (temp.Length == 12)
                        {
                            dice = temp.ToString();
                            return;
                        }
                        else if (matrix[row][col] == "I")
                        {
                            inn++;
                        }
                        temp.Append(matrix[row][col]);
                        col++;
                    }
                    col--;
                    row++;
                }
                if ((row == 1 || row == 2) && col == 3)
                {
                    while (row <= 3)
                    {
                        if (temp.Length == 12)
                        {
                            dice = temp.ToString();
                            return;
                        }
                        else if (matrix[row][col] == "I")
                        {
                            inn++;
                        }
                        temp.Append(matrix[row][col]);
                        row++;
                    }
                    row--;
                    col--;
                }
                if (row == 3)
                {
                    while (col >= 0)
                    {
                        if (temp.Length == 12)
                        {
                            dice = temp.ToString();
                            return;
                        }
                        else if (matrix[row][col] == "I")
                        {
                            inn++;
                        }
                        temp.Append(matrix[row][col]);
                        col--;
                    }
                    col++;
                    row--;
                }
                if ((row == 1 || row == 2) && col == 0)
                {
                    while (row >= 0)
                    {
                        if (temp.Length == 12)
                        {
                            dice = temp.ToString();
                            return;
                        }
                        else if (matrix[row][col] == "I")
                        {
                            inn++;
                        }
                        temp.Append(matrix[row][col]);
                        row--;
                    }
                    row++;
                    col++;
                }
            }
        }
    }
}

