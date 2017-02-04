using System;

class PlusRemove
{
    static void Main()
    {
        string currentLine = Console.ReadLine();
        char[][] input = new char[100][];
        char[][] output = new char[100][];
        int index = 0;

        while (currentLine != "END")
        {
            input[index] = currentLine.ToCharArray();
            output[index] = currentLine.ToCharArray();
            currentLine = Console.ReadLine();
            index++;
        }

        for (int i = 1; i < index - 1; i++)
        {
            for (int j = 1; j < input[i].Length - 1; j++)
            {
                if (input[i].Length - 1 <= input[i + 1].Length &&
                    input[i].Length - 1 <= input[i - 1].Length)
                {
                    string centerElement = input[i][j].ToString().ToLower();
                    string topElement = input[i + 1][j].ToString().ToLower();
                    string leftElement = input[i][j - 1].ToString().ToLower();
                    string bottomElement = input[i - 1][j].ToString().ToLower();
                    string rightElement = input[i][j + 1].ToString().ToLower();

                    if (centerElement == topElement &&
                        centerElement == leftElement &&
                        centerElement == bottomElement &&
                        centerElement == rightElement)
                    {
                        output[i][j] = ' ';
                        output[i + 1][j] = ' ';
                        output[i - 1][j] = ' ';
                        output[i][j + 1] = ' ';
                        output[i][j - 1] = ' ';
                    }
                }
            }
        }

        for (int i = 0; i < index; i++)
        {
            for (int j = 0; j < output[i].Length; j++)
            {
                if (output[i][j] != ' ')
                {
                    Console.Write(output[i][j]);
                }
            }
            Console.WriteLine();
        }
    }
}

