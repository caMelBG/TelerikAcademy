using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class QueryMess
{
    public static List<string> input = new List<string>();

    public static Dictionary<string, StringBuilder> output = 
        new Dictionary<string, StringBuilder>();

    public static string currentLine = String.Empty;

    static void Main()
    {
        ReadInput();

        foreach (string line in input)
        {
            currentLine = RemoveSpaces(line);
            currentLine = RemoveQuestionMark(currentLine);
            SetKeysAndValues(currentLine);
        }

    }

    private static void PrintOutput()
    {
        foreach (KeyValuePair<string, StringBuilder> item in output)
        {
            Console.Write(item.Key + "=" + "[" + item.Value + "]");
        }
        Console.WriteLine();
        output.Clear();
    }

    public static void ReadInput ()
    {
        using (StreamReader myReader = new StreamReader("input.txt"))
        {
            string currentLine = myReader.ReadLine();

            while (currentLine != "END")
            {
                input.Add(currentLine);
                currentLine = myReader.ReadLine();
            }
        }
    }

    public static void SetKeysAndValues (string currentLine)
    {
        string[] array = currentLine.Split('&');
        string currentKey = String.Empty;
        int index = 0;

        foreach (string item in array)
        {
            index = item.IndexOf('=');
            currentKey = item.Substring(0, index).Trim();
            string[] values = item.Substring(index + 1, item.Length - index - 1).Split(' ');

            foreach (string value in values)
            {
                if (value != String.Empty)
                {
                    if (output.ContainsKey(currentKey))
                    {
                        output[currentKey].Append(", " + value.Trim());
                    }

                    else
                    {
                        output.Add(currentKey, new StringBuilder());
                        output[currentKey].Append(value.Trim());
                    }
                }
            }
        }

        PrintOutput();
    }

    public static string RemoveSpaces(string currentLine)
    {
        currentLine = currentLine.Replace("%20", " ");
        currentLine = currentLine.Replace("+", " ");
        return currentLine;
    }

    public static string RemoveQuestionMark(string currentLine)
    {
        int indexQuestioning = currentLine.IndexOf("?");
        if (indexQuestioning != -1)
        {
            currentLine = currentLine.Remove(0, indexQuestioning + 1);
        }

        return currentLine;
    }
}

