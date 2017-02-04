using System;
using System.Text;
using System.Text.RegularExpressions;

class TheNumbers
{
    static void Main()
    {
        StringBuilder output = new StringBuilder();
        StringBuilder number = new StringBuilder();
        string input = "21451AH, KH, QH, JH, 10H, 9H, 5C, 4C, 3C, 2C, AC, 6C, 7C, 5S, 6S, 7S, 8S, 9S, 10S, JS";

        Regex pattern = new Regex("[0-9]");

        for (int i = 0; i < input.Length; i++)
        {
            string symbol = input[i].ToString();
            Match digit = pattern.Match(symbol);
            if (digit.Success)
            {
                number.Append(symbol);
                if (i == input.Length - 1)
                {
                    string result = FormatNumber(number.ToString());
                    output.Append("-" + result);
                }
            }
            else if (number.Length > 0)
            {
                string result = FormatNumber(number.ToString());
                output.Append("-" + result);
                number.Clear();
            }
        }
        output.Remove(0, 1);
        Console.WriteLine(output);

    }

    static string FormatNumber(string number)
    {
        StringBuilder temp = new StringBuilder();
        string hexNumber = Convert.ToInt32(number).ToString("x").ToUpper();
        if (hexNumber.Length < 4)
        {
            temp.Append("0x");
            for (int i = 0; i < 4 - hexNumber.Length; i++)
            {
                temp.Append("0");
            }
            temp.Append(hexNumber);
        }

        else
        {
            temp.Append("0x" + hexNumber);
        }
        hexNumber = temp.ToString();
        return hexNumber;
    }
}

