using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class PhoneNumbers
{
    private static string input;

    private static Dictionary<string, string> phoneBook =
        new Dictionary<string, string>();
    private static StringBuilder name = new StringBuilder();
    private static StringBuilder number = new StringBuilder();
    private static Regex digitPattern = new Regex("[+0-9]");
    private static Regex letterPattern = new Regex("[a-zA-Z]");

    static void Main()
    {
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            input = myReader.ReadToEnd();
            input = input.Remove(input.Length - 3, 3);
        }

        FindNumber();
        Print();
    }

    static void Print()
    {
        if (phoneBook.Count == 0)
        {
            Console.WriteLine("<p>No matches!</p>");
        }

        else
        {
            Console.WriteLine("<ol>");
            foreach (KeyValuePair<string, string> item in phoneBook)
            {
                Console.Write("<li><b>{0}:</b> {1}</li>", item.Key, item.Value);
                Console.WriteLine();
            }
            Console.WriteLine("</ol>");
        }
    }

    private static void FindNumber()
    {
        for (int i = 0; i < input.Length; i++)
        {
            string symbol = input[i].ToString();
            Match match = letterPattern.Match(symbol);
            if (match.Success || i == input.Length - 1)
            {
                if (name.Length > 0)
                {
                    if (number.Length > 0)
                    {
                        AddNumber();
                    }

                    else
                    {
                        name.Clear();
                    }
                }

                while (match.Success)
                {
                    name.Append(symbol);
                    i++;
                    symbol = input[i].ToString();
                    match = letterPattern.Match(symbol);
                }
            }

            match = digitPattern.Match(symbol);
            if (match.Success)
            {
                number.Append(symbol);
            }
        }
    }

    private static void AddNumber()
    {
        string tempName = name.ToString();
        string tempNumber = number.ToString();
        if (tempName[0].ToString() == tempName[0].ToString().ToUpper() &&
            tempNumber.Length > 1)
        {
            phoneBook.Add(tempName, tempNumber);
        }
        name.Clear();
        number.Clear();
    }
}

