using System;
using System.IO;
using System.Text;

class XRemoval
{
    public static char[][] input = new char[100][];

    public static char[][] output = new char[100][];

    public static int index = 0;

    static void Main()
    {
        ReadInput();
        RemoveXElements();
        WriteOutput();

    }

    private static void WriteOutput()
    {
        for (int row = 0; row < index; row++)
        {
            for (int col = 0; col < output[row].Length; col++)
            {
                if (output[row][col] != ' ')
                {
                    Console.Write(output[row][col]);
                }
            }
            Console.WriteLine();
        }
    }

    public static void RemoveXElements()
    {
        for (int row = 1; row < index - 1; row++)
        {
            for (int col = 1; col < input[row].Length - 1; col++)
            {
                if (input[row - 1].Length > col + 1 && input[row + 1].Length > col + 1)
                {
                    string center = input[row][col].ToString().ToLower();
                    string topLeft = input[row - 1][col - 1].ToString().ToLower();
                    string bottomLeft = input[row + 1][col - 1].ToString().ToLower();
                    string topRight = input[row - 1][col + 1].ToString().ToLower();
                    string bottomRight = input[row + 1][col + 1].ToString().ToLower();

                    if (center == topLeft && center == bottomLeft &&
                        center == topRight && center == topRight)
                    {
                        output[row][col] = ' ';
                        output[row - 1][col - 1] = ' ';
                        output[row + 1][col - 1] = ' ';
                        output[row - 1][col + 1] = ' ';
                        output[row + 1][col + 1] = ' ';
                    }
                }
            }
        }
    }

    public static void ReadInput()
    {
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            string currentLine = myReader.ReadLine();
            while (currentLine != "END")
            {
                input[index] = new char[currentLine.Length];
                input[index] = currentLine.ToCharArray();
                output[index] = new char[currentLine.Length];
                output[index] = currentLine.ToCharArray();
                currentLine = myReader.ReadLine();
                index++;
            }
        }
    }
}