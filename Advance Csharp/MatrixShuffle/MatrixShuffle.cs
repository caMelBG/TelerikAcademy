using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class MatrixShuffle
{
    static int size;

    static string input;

    static char[,] matrix;

    static void Main()
    {
        ReadInput();
        FillingMatrix();
        string result = ExtractPalindrome();
        Print(result);
    }

    static void Print(string input)
    {
        StringBuilder tempString = new StringBuilder();

        Regex pattern = new Regex("[a-zA-Z]");
        MatchCollection symboles = pattern.Matches(input);

        foreach (var symbol in symboles)
        {
            tempString.Append(symbol.ToString().ToLower());
        }

        string word = tempString.ToString();
        char[] array = word.ToCharArray();
        Array.Reverse(array);
        string reverse = new string(array);
        Console.WriteLine(reverse);
        Console.WriteLine(word);

        string bgcolor = "#E0000F";
        if (word == reverse)
        {
            bgcolor = "#4FE000";
        }
        Console.WriteLine(@"<div style = 'background-color:{0}' > {1} </ div >", bgcolor, input);
    }

    static string ExtractPalindrome()
    {
        StringBuilder fisrtSubString = new StringBuilder();
        StringBuilder secondSubString = new StringBuilder();
        int index = 0;
        for (int i = 0; i < size; i++)
        {
            if (i % 2 == 0)
            {
                index = 0;
            }

            else
            {
                index = 1;
            }

            for (int j = index; j < size; j += 2)
            {
                if (index == 0)
                {
                    fisrtSubString.Append(matrix[i, j]);
                    if (j + 1 < size)
                    {
                        secondSubString.Append(matrix[i, j + 1]);
                    }
                }

                else
                {
                    fisrtSubString.Append(matrix[i, j]);
                    secondSubString.Append(matrix[i, j - 1]);
                }
            }
        }

        string finalString = fisrtSubString.ToString() + secondSubString.ToString();
        return finalString;
    }

    static void FillingMatrix()
    {
        bool end = true;
        int index = 0;

        int toRightIndex = size;
        int toRightRow = 0;
        int toRightCol = 0;

        int toDownIndex = size - 2;
        int toDownRow = toRightRow + 1;
        int toDownCol = size - 1;

        int toLeftIndex = size;
        int toLeftRow = size - 1;
        int toLeftCol = size - 1;

        int toUpIndex = size - 2;
        int toUpRow = size  - 2;
        int toUpCol = toRightCol;

        while (end)
        {
            for (int i = 0; i < toRightIndex; i++)
            {
                matrix[toRightRow, toRightCol + i] = input[index];
                index++;
            }

            if (index == input.Length)
            {
                end = false;
                break;
            }
            toRightIndex -= 2;
            toRightRow++;
            toRightCol++;

            for (int i = 0; i < toDownIndex; i++)
            {
                matrix[toDownRow + i, toDownCol] = input[index];
                index++;
            }
            if (index == input.Length)
            {
                end = false;
                break;
            }
            toDownIndex -= 2;
            toDownRow++;
            toDownCol--;

            for (int i = 0; i < toLeftIndex; i++)
            {
                matrix[toLeftRow, toLeftCol - i] = input[index];
                index++;
            }
            if (index == input.Length)
            {
                end = false;
                break;
            }
            toLeftRow--;
            toLeftCol--;
            toLeftIndex -= 2;

            for (int i = 0; i < toUpIndex; i++)
            {
                matrix[toUpRow - i, toUpCol] = input[index];
                index++;
            }
            if (index == input.Length)
            {
                end = false;
                break;
            }
            toUpIndex -= 2;
            toUpRow--;
            toUpCol++;
        }

    }

    static void ReadInput()
    {
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            size = int.Parse(myReader.ReadLine());
            input = myReader.ReadToEnd();
            matrix = new char[size, size];
        }
    }
}

