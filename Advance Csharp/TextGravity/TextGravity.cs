using System;
using System.IO;
using System.Security;

class TextGravity
{
    static char[][] matrix = new char[30][];

    static int index = 0;

    static int lineLength = 0;

    static string input = String.Empty;

    static void Main()
    {
        ReadInput();
        FillingMatrix();
        FormatMatrix();
        WriteOutput();
    }
    
    static void WriteOutput()
    {
        Console.WriteLine("<table>");
        for (int i = 0; i < index; i++)
        {
            Console.WriteLine("   <tr>");
            for (int j = 0; j < lineLength; j++)
            {
                Console.WriteLine("      <td>");
                Console.WriteLine("      " + 
                    SecurityElement.Escape(matrix[i][j].ToString()));
                Console.WriteLine("      </td>");
            }
            Console.WriteLine();
            Console.WriteLine("   </tr>");
        }

        Console.WriteLine("</table>");
    }

    static void FormatMatrix()
    {
        for (int i = index - 1; i >= 0; i--)
        {
            for (int j = lineLength - 1; j >= 0; j--)
            {
                for (int l = 0; l <= i; l++)
                {
                    if (matrix[i - l][j] == ' ')
                    {
                        continue;
                    }

                    else if (l != 0)
                    {
                        matrix[i][j] = matrix[i - l][j];
                        matrix[i - l][j] = ' ';
                    }
                    break;
                }
            }
        }
    }

    static void FillingMatrix()
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            if (input.Length < lineLength)
            {
                matrix[i] = input
                    .Insert(input.Length, new string(' ', lineLength - input.Length))
                    .ToCharArray();
                index = i + 1;
                break;
            }

            else
            {
                matrix[i] = input.Substring(0, lineLength).ToCharArray();
                input = input.Remove(0, lineLength);
            }
        }
    }

    static void ReadInput()
    {
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            lineLength = int.Parse(myReader.ReadLine());
            input = myReader.ReadToEnd();
        }
    }
}

