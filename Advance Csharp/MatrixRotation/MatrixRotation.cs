using System;

public class MatrixRotation
{
    static void Main()
    {
        int maxLineLenght = 0;
        int index = 0;
        int rotateValue = int.Parse(Console.ReadLine());
        rotateValue = rotateValue % 360;
        char[][] input = new char[1000][];
        string currentLine = Console.ReadLine();

        while (currentLine != "END")
        {
            input[index] = currentLine.ToCharArray();
            if (maxLineLenght < currentLine.Length)
            {
                maxLineLenght = currentLine.Length;
            }
            currentLine = Console.ReadLine();
            index++;
        }

        if (rotateValue == 0)
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(input[i]);
            }
        }

        else if (rotateValue == 90)
        {
            for (int i = 0; i < maxLineLenght; i++)
            {
                for (int j = index - 1; j >= 0; j--)
                {
                    if (i < input[j].Length)
                    {
                        Console.Write(input[j][i]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        else if (rotateValue == 180)
        {
            for (int i = index - 1; i >= 0; i--)
            {
                for (int j = maxLineLenght - 1; j >= 0; j--)
                {
                    if (j < input[i].Length)
                    {
                        Console.Write(input[i][j]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        else if (rotateValue == 270)
        {
            for (int i = maxLineLenght - 1; i >= 0; i--)
            {
                for (int j = 0; j < index; j++)
                {
                    if (i < input[j].Length)
                    {
                        Console.Write(input[j][i]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}