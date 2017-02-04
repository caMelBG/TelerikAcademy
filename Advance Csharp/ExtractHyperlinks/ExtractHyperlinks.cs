using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class ExtractHyperlinks
{
    static void Main()
    {
        StreamReader myReader = new StreamReader("test.000.001.in.txt");

        List<string> output = new List<string>();

        string currentLine = myReader.ReadLine();

        StringBuilder temp = new StringBuilder();

        while (currentLine != "END")
        {
            temp.Append(currentLine);
            currentLine = myReader.ReadLine();
        }

        myReader.Close();

        string inputText = temp.ToString();

        int index = 0;

        while (inputText.Length > 30)
        {
            if (index != -1)
            {
                index = inputText.IndexOf("<a");
                inputText = inputText.Remove(0, index + 2);
            }

            if (index != -1)
            {
                index = inputText.IndexOf("href");
                inputText = inputText.Remove(0, index + 4);
            }

            if (index != -1)
            {
                index = inputText.IndexOf('\"');
                inputText = inputText.Remove(0, index + 1);

            }

            if (index != -1)
            {
                index = inputText.IndexOf('\"');
            }

            if (index != -1)
            {
                Console.WriteLine(inputText.Substring(0, index));
                output.Add(inputText.Substring(0, index));
            }
        }

    }
}

