using System;
using System.Collections.Generic;
using System.IO;

class SemanticHTML
{
    public static List<string> input = new List<string>();

    public static string[] tags = {
        "main", "header", "nav", "article", "section", "aside", "footer"
    };

    public static int firstIndex;

    public static int secondIndex;

    static void Main()
    {
        ReadInput();
        PrintOutput();
    }

    public static void PrintOutput()
    {
        foreach (string currentLine in input)
        {
            Console.WriteLine(LocateTags(currentLine));
        }
    }

    public static string RemoveTags(string currentLine, string tag, bool isFirst)
    {
        if (isFirst)
        {
            firstIndex = currentLine.IndexOf(tag);
            for (int i = firstIndex - 4; i >= 0; i--)
            {
                if (currentLine[i] == ' ')
                {
                    firstIndex = i;
                    break;
                }
            }
            secondIndex = currentLine.IndexOf(tag) + tag.Length + 2;
        }

        else
        {
            firstIndex = currentLine.LastIndexOf('<');
            secondIndex = currentLine.LastIndexOf('>') + 1;
        }

        currentLine = currentLine.Remove(firstIndex, secondIndex - firstIndex);
        currentLine = currentLine.Replace("div", tag);
        return currentLine;
    }

    public static string LocateTags(string currentLine)
    {
        foreach (string tag in tags)
        {
            if (currentLine.Contains(tag))
            {
                if (currentLine.Contains("<div"))
                {
                    return RemoveTags(currentLine, tag, true);
                }

                else if (currentLine.Contains("</div>"))
                {
                    return RemoveTags(currentLine, tag, false);
                }
            }
        }
        return currentLine;
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
        }
    }
}
