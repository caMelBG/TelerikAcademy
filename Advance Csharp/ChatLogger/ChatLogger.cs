using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class ChatLogger
{
    static SortedDictionary<DateTime, string> input =
        new SortedDictionary<DateTime, string>();

    static DateTime currentDateTime = new DateTime();

    static void Main()
    {
        ReadInput();
        WriteOutput();
    }

    static void WriteOutput()
    {
        string timeAgo = String.Empty;
        DateTime lastActiveDate = new DateTime();
        foreach (var item in input)
        {
            Console.WriteLine("<div>{0}</div>", item.Value);
            lastActiveDate = item.Key;
        }

        TimeSpan span = currentDateTime.Subtract(lastActiveDate);
        if (currentDateTime.Day - lastActiveDate.Day == 1)
        {
            timeAgo = "yesterday";
        }
        else if (currentDateTime.Day - lastActiveDate.Day > 1)
        {
            timeAgo = string.Format("{0}-{1}-{2}",
                lastActiveDate.Day, lastActiveDate.Month, lastActiveDate.Year);
        }
        else if (span.Hours > 0)
        {
            timeAgo = string.Format("{0}hour(s) ago", span.Hours);
        }
        else if (span.Minutes > 0)
        {
            timeAgo = string.Format("{0} minute(s) ago", span.Minutes);
        }
        else if (span.Seconds > 0)
        {
            timeAgo = "a few moments ago";
        }

        Console.WriteLine("<p>Last active: <time>{0}</time></p>", timeAgo);
    }

    static void ReadInput()
    {
        string message = String.Empty;
        DateTime dateTime = new DateTime();
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            currentDateTime = DateTime.ParseExact(myReader.ReadLine().Trim(),
                        "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string currentLine = myReader.ReadLine();
            while (currentLine != "END")
            {
                message = currentLine.Substring(0, currentLine.LastIndexOf('/') - 1);
                string temp = currentLine.Substring(currentLine.LastIndexOf('/') + 2,
                    currentLine.Length - currentLine.LastIndexOf('/') - 2);

                dateTime = DateTime.ParseExact(temp,
                    "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                input.Add(dateTime, message);
                currentLine = myReader.ReadLine();

            }
        }
    }
}

